using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public Vector2 acceleration;
    public float gravity = -9.81f;

    private void Update()
    {
        if (acceleration.y > -20) acceleration.y += (4 * gravity) * Time.deltaTime;

        transform.Translate(acceleration * Time.deltaTime, Space.World);
    }
}
