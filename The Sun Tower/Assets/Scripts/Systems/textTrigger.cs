using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textTrigger : MonoBehaviour
{
    bool isTalking = false;

    int index = 0;

    public string[] texts;

    public PlayerScript playerScript;

    public GameObject canvasUI;
    public TextMeshProUGUI textMeshPro;

    // Update is called once per frame
    void Update()
    {
        if (isTalking)
        {
            playerScript.canWalk = false;

            if (index == texts.Length)
            {
                canvasUI.SetActive(false);
                playerScript.canWalk = true;
                isTalking = false;
                index = 0;
                Destroy(gameObject);
            }
            else
            {
                textMeshPro.SetText(texts[index]);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                index++;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTalking = true;
            canvasUI.SetActive(true);
        }
    }
}
