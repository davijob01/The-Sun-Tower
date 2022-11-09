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

    [Header("General Vars")]

    [HideInInspector] public bool knockbacked;
    public float knockbackForce;
    public float knockbackDecay = 50;

    bool isRight;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("enemy"))
        {
            knockbacked = true;

            if(collision.gameObject.transform.position.x > playerTR.position.x)
            {
                playerGravity.acceleration.x = -knockbackForce;
                isRight = true;
            }

            else
            {
                playerGravity.acceleration.x = knockbackForce;
                isRight = false;
            }
        }
    }

    private void Update()
    {
        if (knockbacked)
        {
            if (isRight)
            {
                playerGravity.acceleration.x += (float)(knockbackDecay * Time.deltaTime);
            }
            else
            {
                playerGravity.acceleration.x -= (float)(knockbackDecay * Time.deltaTime);
            }
        }

        if(isRight && playerGravity.acceleration.x >= 0 || !isRight && playerGravity.acceleration.x <= 0)
        {
            playerGravity.acceleration.x = 0;
            knockbacked = false;
        }
    }

}
