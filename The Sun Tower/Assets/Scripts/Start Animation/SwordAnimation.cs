using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;

public class SwordAnimation : MonoBehaviour
{
    public GameObject blackFade;

    public float startCooldown = 3f;
    float timer = 0f;

    public float start2Cooldown = 1f;
    float timer2 = 0f;

    public float rotationMaxSpeed;
    public float rotationSpeed = 0f;
    public float rotationIncreaseSpeed;

    public float speed;
    public float maxSpeed;
    public float speedIncrease;

    public float animationFullTime = 4f;
    float animationTimer = 0f;

    bool playingAnimation = false;
    bool animationPlayed = false;

    bool playingAnimation2 = false;
    bool startAnimation2 = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = startCooldown;
        timer2 = start2Cooldown;
        animationTimer = animationFullTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0f) timer -= Time.deltaTime;
        
        else if(!animationPlayed) playingAnimation = true;

        if (playingAnimation)
        {
            if(rotationSpeed < rotationMaxSpeed)
            {
                rotationSpeed += rotationIncreaseSpeed * Time.deltaTime;
            }

            animationTimer -= Time.deltaTime;

            if (animationTimer > 0)
            {
                transform.Rotate(0, 0, -rotationSpeed);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
                playingAnimation = false;
                animationPlayed = true;

                playingAnimation2 = true;
            }
        }

        if (playingAnimation2)
        {
            if (timer2 > 0f) timer2 -= Time.deltaTime;

            else startAnimation2 = true;
        }
        
        if (startAnimation2)
        {
            if(speed < maxSpeed)
            {
                speed += speedIncrease * Time.deltaTime;
            }

            transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
        }


    if(transform.position.x >= 10000)
        {
            blackFade.SetActive(true);
        }
    }
}
