using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinShooter : MonoBehaviour
{
    public GameObject shooterObject;
    public float speedOfRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shooterObject.transform.Rotate(0.0f, 0.0f, speedOfRotation, Space.World);
    }
}