using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpeedManipulator : MonoBehaviour
{
    [SerializeField] PlayerScript playerScript;

    float startSpeed;

    private void Awake()
    {
        startSpeed = playerScript.speed;
    }

    public void ChangePlayerSpeed(float desiredSpeed)
    {
        playerScript.speed = desiredSpeed;
    }

    public void RestartSpeed()
    {
        playerScript.speed = startSpeed;
    }
}
