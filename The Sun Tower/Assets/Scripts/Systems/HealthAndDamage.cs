using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDamage : MonoBehaviour
{
    public Animator animator;

    public float health = 3;
    public int damage = 1;

    bool canTakeDamage = true;

    float timer = 0f;
    float damageCooldown = 0.15f;

    private void Update()
    {
        if (!canTakeDamage)
        {
            timer += Time.deltaTime;

            if(timer >= damageCooldown)
            {
                canTakeDamage = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("hitbox") && canTakeDamage)
        {
            animator.SetTrigger("damageTaken");

            health -= collision.gameObject.GetComponent<HitBox>().damage;
            canTakeDamage = false;

            if (health <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
