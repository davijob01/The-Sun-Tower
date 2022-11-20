using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyingEnemyScript : MonoBehaviour
{
    public AIPath aIPath;
    public playerFlyingDetector playerDetector;
    public Transform playerTR;

    void Start()
    {
        aIPath.enabled = false;
        playerTR = GameObject.Find("Igu").GetComponent<Transform>();
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
    }
}
