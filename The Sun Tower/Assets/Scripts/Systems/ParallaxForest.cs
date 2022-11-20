using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxForest : MonoBehaviour
{
    public GameObject camPlayer;

    float imageSize;

    Vector2 startPos;

    public float parallaxSpeed;

    void Start()
    {
        startPos = transform.position;
        imageSize = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float temp = (camPlayer.transform.position.x * (1 - parallaxSpeed));
        float dist = (camPlayer.transform.position.x * parallaxSpeed);

        transform.position = new Vector3(startPos.x + dist, startPos.y, transform.position.z);

        if(temp > startPos.x + imageSize / 2)
        {
            startPos.x += imageSize;
        }

        else if (temp < startPos.x - imageSize / 2)
        {
            startPos.x -= imageSize;
        }
    }
}
