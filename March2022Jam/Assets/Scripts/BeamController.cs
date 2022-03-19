using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour
{
    public Transform playerTransform;
    public bool trigger = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger == true){
            Target();
            trigger = false;
        }
    }

    public void Attack()
    {
        //activate indicators
        Target();
        //pause and wait
        //change indicator to actual beam
        //activate hitboxes
        //
        //deactivae hitboxes
    }

    private void Target()
    {
        Vector2 direction = playerTransform.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }
}
