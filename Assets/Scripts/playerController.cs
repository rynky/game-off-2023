using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float checkRadius = 0.2f;
    [SerializeField] private float jumpForce = 2f;
    public Transform feet;
    public LayerMask groundLayer;
    
    
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
}
