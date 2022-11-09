using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    public PlayerScript playerScript;

    float initialSpeed;

    public bool inWall;

    private void Start()
    {
        initialSpeed = playerScript.speed;
    }

    private void Update()
    {
        if (inWall) playerScript.speed = 0f;
        
        else playerScript.speed = initialSpeed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            inWall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            inWall = false;
        }
    }
}
