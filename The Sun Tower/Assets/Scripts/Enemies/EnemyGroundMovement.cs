using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundMovement : MonoBehaviour
{
    public FloorDetection floorDetector;
    public WallDetector wallDetector;
    public Gravity gravityScr;
    public EnemyGroundCheck groundCheck;

    bool facingRight = true;

    public float speed;

    public float timer = 0.1f;

    // Update is called once per frame
    void Update()
    {
        //SIMPLE CONSTANT MOVEMENT

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        //TURNING CONTROLLER

        if(timer >= 0) timer -= Time.deltaTime;

        if (wallDetector.wallDetected || !floorDetector.groundDetected) TurnEnemy();

        //GRAVITY MANAGEMENT

        if (groundCheck.isGrounded)
        {
            gravityScr.acceleration.y = -0f;
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
