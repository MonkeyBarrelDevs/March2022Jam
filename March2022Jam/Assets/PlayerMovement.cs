using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveAnimThreshold = .1f;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    bool canMove = true;
    Animator playerAnim;

    Vector2 movement;

    private void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement.x = 0;
            movement.y = 0;
        }
        
        playerAnim.SetBool("Walk North", movement.y > moveAnimThreshold);
        playerAnim.SetBool("Walk South", movement.y < -moveAnimThreshold);
        playerAnim.SetBool("Walk East", movement.x > moveAnimThreshold);
        playerAnim.SetBool("Walk West", movement.x < -moveAnimThreshold);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    public void Die()
    {
        canMove = false;
        playerAnim.SetTrigger("Die");
    }
}
