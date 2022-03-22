using UnityEngine;
using System.Collections;
using Pathfinding;
public class RandomDestinationSetter : MonoBehaviour {
    public float radius = 3;
    IAstarAI ai;
    void Start () {
        ai = GetComponent<IAstarAI>();
    }
    public Vector3 PickRandomPoint () {
        var point = Random.insideUnitSphere * radius;
        point.z = 0;
        point += ai.position;
        point -= transform.position;
        return point;
    }

    void Update () {
        // Update the destination of the AI if
        // the AI is not already calculating a path and
        // the ai has reached the end of the path or it has no path at all
        if (!ai.pathPending && (ai.reachedEndOfPath|| !ai.hasPath)) {
            ai.destination = PickRandomPoint();
            ai.SearchPath();
        }
    }
}
