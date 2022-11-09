using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded = false;
    public PlayerScript playerScript;
    public Gravity playerGravity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            if (playerScript.isJumping)
            {
                playerScript.speed /= 1.25f;
                playerScript.isJumping = false;
            }
            isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            isGrounded = false;

            if (!playerScript.isJumping)
            {
                playerGravity.acceleration.y = -3f;
            }
        }
    }
}
