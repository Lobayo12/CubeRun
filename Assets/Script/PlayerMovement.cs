using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float playerMovementSpeed = 5f;

    [SerializeField]
    private float jumpForce = 10f;

    private Rigidbody2D playerRB;
    private bool isGrounded = true;

    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private Transform groundCheck;
    private float groundCheckRadius = 0.2f;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Jump systeme
        if (Input.GetButtonDown("Jump"))
        {
            playerRB.linearVelocity = new Vector2(playerRB.linearVelocity.x, jumpForce); // Apply vertical force
        }
        
    }

    void FixedUpdate()
    {
        // Constant right movement of the player
        playerRB.linearVelocity = new Vector2(playerMovementSpeed, playerRB.linearVelocity.y);
    }
}

