using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    [Header("Player Vars")]

    public Rigidbody2D playerRB;
    public Transform playerTR;
    public Gravity playerGravity;
    public PlayerScript playerScript;

    [Header("General Vars")]

    Gravity enemyGravity;

    public float knockbackForce;
    public float upwardsKnockbackForce;
    public float knockbackDecay = 50;

    public int damage = 1;

    [HideInInspector] public bool knockbacked;
    bool isRight;
    public bool isUpOrDown;

    bool isFlyingEnemy = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("flying enemy"))
        {
            if (!collision.gameObject.CompareTag("flying enemy"))
            {
                isFlyingEnemy = false;
            }
            else
            {
                isFlyingEnemy = true;
            }

            enemyGravity = collision.gameObject.GetComponent<Gravity>();
            
            isUpOrDown = playerScript.hitboxUp || playerScript.hitboxDown;

            //CHECKS IF THE PLAYER IS ATTACKING UP OR DOWN

            if (isUpOrDown)
            {
                if (playerScript.hitboxUp)
                {
                    if(playerGravity.acceleration.y > 0f) playerGravity.acceleration.y = 0f; //CLEARS VERTICAL ACCELERATION IF HITS UP
                
                    playerScript.hitboxUp = false;
                }

                if (playerScript.hitboxDown) //GIVES VERTICAL BOOST IF HITS DOWN
                {
                    if(playerGravity.acceleration.y > 0f)
                    {
                        playerGravity.acceleration.y += upwardsKnockbackForce; 
                    }
                    else
                    {
                        playerGravity.acceleration.y = upwardsKnockbackForce;
                    }

                    playerScript.hitboxDown = false;
                }
            }

            else //IF IT'S NOT ATTACKING UPWARDS OR DOWNWARDS THAN APPLY KNOCKBACK
            {
                //CHECKS IF ENEMY IS ON THE LEFT OR THE RIGHT OF THE PLAYER

                if (collision.gameObject.transform.position.x > playerTR.position.x)
                {
                    playerGravity.acceleration.x = -knockbackForce;//SETS THE KNOCKBACK WITH NEGATIVE FORCE
                    isRight = true;

                    if (!isFlyingEnemy)
                    {
                        enemyGravity.acceleration.x = knockbackForce;
                    }

                }

                else if (collision.gameObject.transform.position.x < playerTR.position.x)
                {
                    playerGravity.acceleration.x = knockbackForce; //SETS THE KNOCKBACK
                    isRight = false;

                    if (!isFlyingEnemy)
                    {
                        enemyGravity.acceleration.x = -knockbackForce;
                    }

                }

                knockbacked = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (knockbacked)
        {
            //SLOWLY STOPPING THE KNOCKBACK

            if (isRight) //IF THE PLAYER IS ON THE RIGHT OF THE ENEMY
            {
                playerGravity.acceleration.x += (float)(knockbackDecay * Time.deltaTime);

                if(!isFlyingEnemy)
                {
                    enemyGravity.acceleration.x -= (float)(knockbackDecay * Time.deltaTime);
                }
            }
            else //IF THE PLAYER IS ON THE LEFT OF THE ENEMY
            {
                playerGravity.acceleration.x -= (float)(knockbackDecay * Time.deltaTime);

                if (!isFlyingEnemy)
                {
                    enemyGravity.acceleration.x += (float)(knockbackDecay * Time.deltaTime);
                }
            }

            //CHECKS IF KNOCKBACK ENDED AND RESETS THE VARIABLES

            if (isRight && playerGravity.acceleration.x >= 0 || !isRight && playerGravity.acceleration.x <= 0)
            {
                playerGravity.acceleration.x = 0;
                knockbacked = false;
            }

            if (!isFlyingEnemy)
            {
                if (isRight && enemyGravity.acceleration.x <= 0 || !isRight && enemyGravity.acceleration.x >= 0)
                {
                    enemyGravity.acceleration.x = 0;
                }
            }

            
        }
    }
}
