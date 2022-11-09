using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofCheck : MonoBehaviour
{
    public Gravity playerGravity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerGravity.acceleration.y = 0f;
    }
}
