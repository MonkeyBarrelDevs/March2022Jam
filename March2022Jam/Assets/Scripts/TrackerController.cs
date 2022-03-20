using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerController : MonoBehaviour
{
    private Transform target;
    public float speed = 5;
    private Rigidbody2D rb;

    public float rotateSpeed = 200;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();
        float rotationAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotationAmount * rotateSpeed;
        rb.velocity = transform.up * speed;
    }
}