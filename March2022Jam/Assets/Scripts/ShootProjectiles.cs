using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectiles : MonoBehaviour
{
    public GameObject[] shooterObjects;
    public GameObject projectileObject;
    public float shootingInterval;
    public float projectileSpeed;

    private float timeSinceShot;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceShot = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceShot += Time.deltaTime;

        if (timeSinceShot > shootingInterval)
        {
            timeSinceShot = 0f;

            for (int i = 0; i < shooterObjects.Length; i++)
            {
                GameObject obj = Instantiate(projectileObject, shooterObjects[i].transform.position, shooterObjects[i].transform.rotation);
                obj.GetComponent<Rigidbody2D>().velocity = obj.transform.up * projectileSpeed;
            }
        }
    }
}
