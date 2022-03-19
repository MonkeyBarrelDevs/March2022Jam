using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinShooter : MonoBehaviour
{
    public GameObject shooterObject;
    public float speedOfRotation;
    public float timeBetweenShakes;
    public bool shakeRotate;

    private float timeSinceShot;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceShot = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeRotate)
        {
            timeSinceShot += Time.deltaTime;

            if (timeSinceShot > timeBetweenShakes)
            {
                speedOfRotation = -speedOfRotation;
                timeSinceShot = 0f;
            }
        }
        
        shooterObject.transform.Rotate(0.0f, 0.0f, speedOfRotation, Space.World);
    }
}
