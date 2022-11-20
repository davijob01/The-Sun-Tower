using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextSceneFade : MonoBehaviour
{
    public GameObject blackFade;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            blackFade.SetActive(true);
        }
    }
}
