using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
protected RandomDestinationSetter moveRandomly;
protected bool isMovingRandomly = true;
protected bool isChasingPlayer = false;

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
            //set chase.enabled = false;
        }
        else if(isChasingPlayer)
        {
            moveRandomly.enabled = false;
            //set chase.enable = true;
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
    }
}
