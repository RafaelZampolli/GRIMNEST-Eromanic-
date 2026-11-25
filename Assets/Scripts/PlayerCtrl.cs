using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{

    public float movSpeed;
    public float walkDuration = 1f; // How long the player walks (in seconds)
    public float stopDuration = 0.5f; // How long the player stops (in seconds)
    public float moveDistance = 2f; // How far the player moves each time
    private float moveTimer;
    private float stopTimer;
    private bool isWalking = false;

    private Vector2 moveDirection;
    private Rigidbody2D rb;

 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveTimer = walkDuration; // Start by walking
    }

    void Update()
    {
        if (isWalking)
        {
            Walk();
        }
        else
        {
            Stop();
        }
    }

    void Walk()
    {
        moveTimer -= Time.deltaTime;

        // Apply movement in the selected direction
        rb.velocity = moveDirection * movSpeed;

        if (moveTimer <= 0f)
        {
            // Stop walking, start idle
            rb.velocity = Vector2.zero;
            isWalking = false;
            stopTimer = stopDuration;
        }
    }

    void Stop()
    {
        stopTimer -= Time.deltaTime;

        if (stopTimer <= 0f)
        {
            // Prepare to walk again
            isWalking = true;
            moveTimer = walkDuration;

            // Get input direction only when starting movement
            moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

            // Now allows diagonal movement
        }
    }
}