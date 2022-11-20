using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerDoor : MonoBehaviour
{
    bool onRange = false;

    public GameObject w;
    public GameObject blackFade;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onRange = true;
            w.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onRange = false;
            w.SetActive(false);
        }
    }

    private void Update()
    {
        if (onRange && Input.GetKeyDown(KeyCode.W))
        {
            blackFade.SetActive(true);
        }
    }

}
