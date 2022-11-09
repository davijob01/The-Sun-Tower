using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using UnityEditor.Rendering;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerScript : MonoBehaviour
{                                          
    //CHECKS////////////////////////////////////////////////////
                                                      
    [HideInInspector] public bool isJumping = false;  
    [HideInInspector] public bool facingRight = true; 
    
    //ATTACK////////////////////////////////////////////////////

    public float atkCooldown = 0.25f;                  
    float atkCountdown = 0f;                        
    float atkTimer = 0f;                              
    public float atkDuration = 0.15f;                        
                                                      
    //OBJECTS///////////////////////////////////////////////////
                                                      
    public GameObject hitBox;                         
    public GroundCheck groundCheck;
    public Gravity gravityScr;
                                                      
    //MOVEMENT//////////////////////////////////////////////////
                                                 
    public float speed = 5.0f;                   
    public float jumpForce = 10f;                
                                                 
    ////////////////////////////////////////////////////////////
    
    void Update()
    {
        //MOVEMENT
        
        float horizontalInput = Input.GetAxis("Horizontal"); //gets the unity's default horizontal input
        transform.Translate(Vector2.right * speed * horizontalInput * Time.deltaTime, Space.World); //move the player based on it's speed and direction relative to the world

        //checks if the last time player moved he was moving right or left and stores the information

        if (horizontalInput > 0) facingRight = true;
       
        else if (horizontalInput < 0) facingRight = false;

        //GRAVITY
        
        //while grounded the fall speed is 0, check if it's not jumping for debbuging
        if (groundCheck.isGrounded && !isJumping)
        {
            gravityScr.acceleration.y = -0.03f;
            gravityScr.gravity = 0f;
        }
        else
        {
            gravityScr.gravity = -9.87f;
        }

        //JUMPING

        if (Input.GetKeyDown(KeyCode.Space) && groundCheck.isGrounded && !isJumping) //normal checks to realize the jumping actions
        {
            isJumping = true;
            speed *= 1.25f; //higher speed while jumping
            gravityScr.acceleration.y = jumpForce;
        }
        if (Input.GetKeyUp(KeyCode.Space) && isJumping && gravityScr.acceleration.y > 1f) //checks if the key was let go while the player was jumping up to cancel the momentum
        {
            gravityScr.acceleration.y = 1f;
        }

        //ROTATION

        if (facingRight && atkTimer <= 0f) //checks if it's facing right and if it's not attacking and then change the y rotation to 0
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(!facingRight && atkTimer <= 0f) //checks if it's facing left and if it's not attacking and then change the y rotation to 180
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        //ATTACK

        //countsdown the timers for cooldown and duration

        if(atkCountdown > 0f) atkCountdown -= Time.deltaTime;
        if(atkTimer > 0f) atkTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.J) && atkCountdown <= 0f)
        {
            //resets the timers for the attack's cooldown and duration

            hitBox.transform.position = new Vector3(0, 0, 0);

            atkCountdown = atkCooldown;
            atkTimer = atkDuration;

            //checks if the attack is normal or up/down and realocates the hitbox accordingly

            if (Input.GetKey(KeyCode.W)) //checks if the attack is up
            {
                hitBox.transform.localPosition = new Vector3(0, 1.5f, 0);
                hitBox.transform.localRotation = Quaternion.Euler(0, 0, 90);
            }
            else if (Input.GetKey(KeyCode.S) && !groundCheck.isGrounded) //checks if the attack is down and if the player is jumping
            {
                hitBox.transform.localPosition = new Vector3(0, -1.5f, 0);
                hitBox.transform.localRotation = Quaternion.Euler(0, 0, 90);
            }
            else //normal attack
            {
                hitBox.transform.localPosition = new Vector3(1.5f, 0, 0);
                hitBox.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

        }

        if (atkTimer <= 0f && hitBox.activeSelf) //despawns the hitbox after attack duration and resets it's position and rotation
        {
            hitBox.transform.position = new Vector3(0, 0, -15);
            hitBox.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

    }
}
