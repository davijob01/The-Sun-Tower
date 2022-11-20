using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    bool onRange = false;

    public GameObject w;

    public GameObject bulb;
    public GameObject animationBuld;

    public GameObject bulbLight;

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

    void Update()
    {
        if (onRange)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                bulb.SetActive(false);
                bulbLight.SetActive(false);
                animationBuld.SetActive(true);
            }
        }
    }
}
