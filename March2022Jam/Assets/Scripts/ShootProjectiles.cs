using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShootProjectiles : MonoBehaviour
{
    public GameObject[] shooterObjects;
    public GameObject projectileObject;
    public float shootingInterval;
    public float projectileSpeed;


    public List<Vector3> circleShooterPoints = new List<Vector3>();
    public GameObject shooterObject;
    public int numOfShootingPoints;

    private float timeSinceShot;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceShot = 0f;
        DrawCirclePoints(numOfShootingPoints, 1.0, shooterObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceShot += Time.deltaTime;

        if (timeSinceShot > shootingInterval)
        {
            timeSinceShot = 0f;

            /*
            for (int i = 0; i < shooterObjects.Length; i++)
            {
                GameObject obj = Instantiate(projectileObject, shooterObjects[i].transform.position, shooterObjects[i].transform.rotation);
                obj.GetComponent<Rigidbody2D>().velocity = obj.transform.up * projectileSpeed;
            }
            */
            for (int j = 0; j < numOfShootingPoints; j++)
            {
                GameObject obj = Instantiate(projectileObject, circleShooterPoints[j], Quaternion.identity);
                obj.GetComponent<Rigidbody2D>().velocity = circleShooterPoints[j] - projectileObject.transform.position * projectileSpeed;
                Debug.Log(circleShooterPoints[j]);
            }
        }
    }

    void DrawCirclePoints(int points, double radius, Vector3 center)
    {
        double slice = 2 * Math.PI / points;
        for (int i = 0; i < points; i++)
        {
            double angle = slice * i;
            float newX = (float)(center.x + radius * Math.Cos(angle));
            float newY = (float)(center.y + radius * Math.Sin(angle));
            circleShooterPoints.Add(new Vector3(newX, newY, 0f));
        }
    }
}
