using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsCheck : MonoBehaviour
{
    public bool flowerPattern;
    public float projectileSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnBecameInvisible()
    {
        if (flowerPattern)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.transform.up * -1 * projectileSpeed;
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
