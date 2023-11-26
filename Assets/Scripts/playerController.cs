using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float checkRadius = 0.2f;
    [SerializeField] private float jumpForce = 2f;
    private float xInput;
    public Transform feet;
    public LayerMask groundLayer;
    private bool facingRight = true;
    
    private Rigidbody2D rb;
    private bool isGrounded;
    public float scaleFactor = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Horizontal Input
        xInput = Input.GetAxis("Horizontal");

        // Calculate Movement based on horizontal input
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

        // Flip character if facing the negative directionn
        if (facingRight && xInput < 0) {
            facingRight = false;
            Flip();
        } 
        else if (!facingRight && xInput > 0)
        {
            facingRight = true;
            Flip();
        }

    }

    public boxController selectedBox = null;

    public void SelectBox(boxController box)
    {
        // There is no box currently selected
        if (selectedBox == null)
        {
            box.Scale(true);
            selectedBox = box;
        } 
        
        // There is a box currently selected
        else
        {
            // If it is the same box, deselect
            if (selectedBox == box)
            {
                box.Scale(false);
                selectedBox = null;
            } 

            // If it is a new box...
            else
            {
                // De-select the previous box
                selectedBox.Scale(false);

                // Select the new box
                box.Scale(true);
                selectedBox = box;
            }
        }
    }

    private void Flip()
    {      
        // Flip the sprite to match the direction that it is travelling in
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
