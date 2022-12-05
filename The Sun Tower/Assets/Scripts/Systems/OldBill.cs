using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OldBill : MonoBehaviour
{
    public bool onRange;
    public bool isTalking = false;

    int index = 0;

    public string[] texts;

    public PlayerScript playerScript;

    public GameObject wSprite;
    public GameObject canvasUI;
    public TextMeshProUGUI textMeshPro;

    private void Update()
    {
        if (onRange)
        {
            if (Input.GetKeyDown(KeyCode.W) && onRange && !isTalking)
            {
                index = 0;
                textMeshPro.SetText(texts[index]);

                canvasUI.SetActive(true);
                wSprite.SetActive(false);

                isTalking = true;
            }
        }

        if (isTalking)
        {
            playerScript.canWalk = false;

            if (Input.GetKeyDown(KeyCode.E))
            {

                index++;

                if (index == texts.Length)
                {
                    canvasUI.SetActive(false);
                    wSprite.SetActive(true);

                    isTalking = false;
                    playerScript.canWalk = true;
                }
                else
                {
                    textMeshPro.SetText(texts[index]);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onRange = true;
            wSprite.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onRange = false;
            wSprite.SetActive(false);
        }
    }
}
