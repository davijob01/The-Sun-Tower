using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundMovement : MonoBehaviour
{
    [Header("Detectors")]

    public FloorDetection floorDetector;
    public WallDetector wallDetector;
    public PlayerDetector playerDetector;

    [Header("Objects")]

    public Transform playerTR;
    public Gravity gravityScr;
    public EnemyGroundCheck groundCheck;

    [Header("Variables")]

    bool facingRight = true;
    public float speed;
    public float runningSpeed;
    [HideInInspector] public float startSpeed;

    private void Start()
    {
        startSpeed = speed;

        playerTR = GameObject.Find("Igu").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //SIMPLE CONSTANT MOVEMENT

        if (playerDetector.playerDetected)
        {
            if(playerTR.position.x < transform.position.x)
            {
                if (!facingRight) TurnEnemy();
            }
            else
            {
                if(facingRight) TurnEnemy();
            }

            if (wallDetector.wallDetected || !floorDetector.groundDetected)
            {
                playerDetector.playerDetected = false;
                speed = startSpeed;
            }
        }
        
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        //TURNING CONTROLLER

        if (wallDetector.wallDetected || !floorDetector.groundDetected) TurnEnemy();

        //GRAVITY MANAGEMENT

        if (groundCheck.isGrounded)
        {
            gravityScr.acceleration.y = 0f;
            gravityScr.gravity = 0f;
        }
        else
        {
            gravityScr.gravity = -1f;
        }
    }

    private void TurnEnemy()
    {
        if (facingRight)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            facingRight = false;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            facingRight = true;
        }

        wallDetector.wallDetected = false;
        floorDetector.groundDetected = true;
    }
}
