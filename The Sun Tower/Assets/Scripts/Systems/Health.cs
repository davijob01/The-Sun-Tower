using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numHearts;

    public Image[] lamps;
    public Sprite fullLamp;
    public Sprite brokenLamp;

    public float damageCooldown = 2f;
    public float timer = 0f;

    public Animator animator;

    private void Update()
    {
        if(timer >= 0)
        {
            timer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if(numHearts < 9)
            {
                numHearts = 9;
                health += 4;
            } 
        }

        if(health <= 0)
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.O)) health++;
    }

    void FixedUpdate()
    {
        if(health > numHearts)
        {
            health = numHearts;
        }

        for(int i = 0; i < lamps.Length; i++)
        {
            if(i < numHearts)
            {
                lamps[i].enabled = true;
            }
            else
            {
                lamps[i].enabled = false;
            }

            if(i < health)
            {
                lamps[i].sprite = fullLamp;
            }
            else
            {
                lamps[i].sprite = brokenLamp;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("flying enemy"))
        {
            TakeDamage(collision.gameObject.GetComponent<HealthAndDamage>().damage);
        }
    }

    public void TakeDamage(float damage)
    {
        if(timer <= 0)
        {
            animator.Play("damage");
            health -= (int)damage;
            timer = damageCooldown;
        }
    }
}
