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

        if(Input.GetAxis("Horizontal") >= 0.2 || Input.GetAxis("Horizontal") <= -0.2) playerAnimator.SetBool("isWalking", true);

        else playerAnimator.SetBool("isWalking", false);

        //ATTACK ANIMATION CHECK

        if (playerScript.atackUp) playerAnimator.SetTrigger("attackUp");

        else if (playerScript.atackdown) playerAnimator.SetTrigger("attackDown");
    }
}
