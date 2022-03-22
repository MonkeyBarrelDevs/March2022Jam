using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsCheck : MonoBehaviour
{
    public bool flowerPattern;
    public float projectileSpeed;
    public GameObject shooterObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(gameObject.transform.position.x - shooterObject.transform.position.x) < 0.3 && Math.Abs(gameObject.transform.position.y - shooterObject.transform.position.y) < 0.3)
        {
            Destroy(gameObject);
        }

        double bulletX = gameObject.transform.position.x;
        double bulletY = gameObject.transform.position.y;
        double circleRadius = 17.0;

        if (Math.Pow(bulletX, 2) + Math.Pow(bulletY, 2) - Math.Pow(circleRadius, 2) > 0)
        {
            Destroy(gameObject);
        }

    }
    private void OnBecameInvisible()
    {
        if (flowerPattern)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.transform.up * -1 * projectileSpeed;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
