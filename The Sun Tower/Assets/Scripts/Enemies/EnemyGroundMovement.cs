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
    public Animator enemyAnimator;

    [Header("Variables")]

    bool facingRight = true;
    public float speed;
    public float runningSpeed;
    [HideInInspector] public float startSpeed;
    
    float stopDelay;
    float nextStop;
    float standTime;
    float stopStanding;
    bool isWalking = true;

    private void Start()
    {
        stopDelay = Random.Range(7f, 12f);
        standTime = Random.Range(3f, 4f);

        nextStop = Time.time + stopDelay;

        startSpeed = speed;

        playerTR = GameObject.Find("Igu").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //SIMPLE CONSTANT MOVEMENT

        if (playerDetector.playerDetected)
        {
            enemyAnimator.SetBool("isWalking", true);

            if (playerTR.position.x < transform.position.x)
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

        //STOPPING SYSTEM

        if(Time.time >= nextStop && isWalking && !playerDetector.playerDetected)
        {
            enemyAnimator.SetBool("isWalking", false);
            speed = 0f;

            isWalking = false;

            stopStanding = Time.time + standTime;
            standTime = Random.Range(2f, 3f);
        }

        if (Time.time >= stopStanding && !isWalking)
        {
            enemyAnimator.SetBool("isWalking", true);
            speed = startSpeed;

            nextStop = Time.time + stopDelay;
            stopDelay = Random.Range(7f, 12f);
            
            isWalking = true;
        }

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
