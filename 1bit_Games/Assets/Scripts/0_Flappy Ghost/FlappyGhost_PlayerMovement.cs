using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyGhost_PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    Rigidbody2D rb;    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(0, jumpForce);
        }
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }
}
