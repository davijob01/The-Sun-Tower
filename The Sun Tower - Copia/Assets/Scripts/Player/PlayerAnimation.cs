using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator playerAnimator;

    private void Update()
    {
        if(Input.GetAxis("Horizontal") >= 0.2 || Input.GetAxis("Horizontal") <= -0.2) playerAnimator.SetBool("isWalking", true);

        else playerAnimator.SetBool("isWalking", false);
    }
}
