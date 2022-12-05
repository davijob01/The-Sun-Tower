using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public PlayerScript playerScript;

    public Animator playerAnimator;

    private void Update()
    {
        //WALKING ANIMATION CHECK

        if (playerScript.canWalk)
        {
            if (Input.GetAxis("Horizontal") >= 0.2 || Input.GetAxis("Horizontal") <= -0.2) playerAnimator.SetBool("isWalking", true);

            else playerAnimator.SetBool("isWalking", false);
        }

        else playerAnimator.SetBool("isWalking", false);

        //GROUNDED CHECK

        if (playerScript.groundCheck.isGrounded) playerAnimator.SetBool("isGrounded", true);

        else playerAnimator.SetBool("isGrounded", false);

        //ATTACK ANIMATION CHECK

        if (playerScript.atackUp)
        {
            playerAnimator.SetTrigger("attackUp");
            playerScript.atackUp = false;
        }

        else if (playerScript.atackdown)
        {
            playerAnimator.SetTrigger("attackDown");
            playerScript.atackdown = false;
        }

        else if (playerScript.atack)
        {
            playerAnimator.SetTrigger("attack");
            playerScript.atack = false;
        }
    }
}
