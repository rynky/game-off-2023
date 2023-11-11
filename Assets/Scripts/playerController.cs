using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed = 5f;
    public Transform feet;
    public LayerMask groundLayer;
    public float checkRadius = 0.2f;
    public float jumpForce = 2f;
    
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Horizontal Movement
        float xInput = Input.GetAxis("Horizontal");

        Vector2 newMovementVector = new Vector2(xInput * speed, rb.velocity.y);
        rb.velocity = newMovementVector;

        // Check if the player is on the ground
        if (Physics2D.OverlapCircle(feet.position, checkRadius, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        // Jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
