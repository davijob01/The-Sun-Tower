using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    public GameObject player;
    public Transform tpTransform;

    public Health playerHealth;
    public Gravity playerGravity;

    private void Start()
    {
        playerHealth = GameObject.Find("Igu").GetComponent<Health>();
        playerGravity = GameObject.Find("Igu").GetComponent<Gravity>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = tpTransform.position;
            playerGravity.acceleration.y = 0f;
            playerHealth.TakeDamage(1);
        }
    }
}
