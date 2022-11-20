using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofCheck : MonoBehaviour
{
    public Gravity playerGravity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            playerGravity.acceleration.y = 0f;
        }
    }
}
