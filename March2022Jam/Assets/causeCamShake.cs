using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class causeCamShake : MonoBehaviour
{
    public cameraShake cameraShake;
    [SerializeField]
    [Range(0, 50)]
    public float duration = 0.15f;
    [Range(0,50)]
    public float magnitude = 0.4f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(cameraShake.Shake(duration, magnitude));
        }
    }
}
