using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyingEnemyScript : MonoBehaviour
{
    public AIPath aIPath;
    public AIDestinationSetter aiDestination;
    public playerFlyingDetector playerDetector;
    public Transform playerTR;

    float startSpeed;

    float stunnedTime = .1f;
    float stopStunTime = 0f;
    bool hit = false;
    bool stunned = false;

    void Start()
    {
        aIPath.enabled = false;
        playerTR = GameObject.Find("Igu").GetComponent<Transform>();
        startSpeed = aIPath.maxSpeed;
        aiDestination.target = GameObject.Find("Igu").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTR.position.x < transform.position.x) transform.rotation = Quaternion.Euler(0, 0, 0);

        else if(playerTR.position.x > transform.position.x) transform.rotation = Quaternion.Euler(0, 180, 0);

        if (playerDetector.playerDetected)
        {
            aIPath.enabled = true;
        }
        else
        {
            aIPath.enabled = false;
        }

        //HIT STOP

        if (hit)
        {
            stopStunTime = Time.time + stunnedTime;

            hit = false;
            stunned = true;
        }

        if (stunned)
        {
            aIPath.maxSpeed = 0;

            if (Time.time >= stopStunTime)
            {
                hit = false;
                aIPath.maxSpeed = startSpeed;
                stunned = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("hitbox") && !hit)
        {
            hit = true;
        }
    }
}
