using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFlyingDetector : MonoBehaviour
{
    public bool playerDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerDetected = false;
        }
    }
}
