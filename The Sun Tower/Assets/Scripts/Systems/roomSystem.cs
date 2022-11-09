using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomSystem : MonoBehaviour
{
    public GameObject virtualCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            virtualCamera.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            virtualCamera.SetActive(false);
        }
    }
}
