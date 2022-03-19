using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class causeCamShake : MonoBehaviour
{
    public cameraShake cameraShake;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(cameraShake.Shake(.15f,.4f));
        }
    }
}
