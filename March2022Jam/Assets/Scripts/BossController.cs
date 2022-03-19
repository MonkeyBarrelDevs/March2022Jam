using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BossController : MonoBehaviour
{
protected RandomDestinationSetter moveRandomly;
protected AIDestinationSetter moveTowardsPlayer;
protected bool isMovingRandomly = false;
protected bool isChasingPlayer = true;

    // Start is called before the first frame update
    void Start()
    {
        FindReferences();
    }

    protected void MovePhaseCheck(bool isMovingRandomly, bool isChasingPlayer)
    {
        if(isMovingRandomly)
        {
            moveRandomly.enabled = true;
            moveTowardsPlayer.enabled = false;
        }
        else if(isChasingPlayer)
        {
            moveTowardsPlayer.enabled = true;
            moveRandomly.enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        MovePhaseCheck(isMovingRandomly, isChasingPlayer);
    }

    void FindReferences()
    {
        moveRandomly = gameObject.GetComponent<RandomDestinationSetter>();
        moveTowardsPlayer = gameObject.GetComponent<AIDestinationSetter>();
    }
}
