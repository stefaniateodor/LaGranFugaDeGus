using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovGusano : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public float moveSpeed = 2f;  // Speed at which the worm moves
    public float detectionRange = 5f;  // Range within which the worm detects the player

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check the distance between the worm and the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // If the player is within detection range, move towards the player
        if (distanceToPlayer < detectionRange)
        {
            MoveTowardsPlayer();
        }
        else
        {
            // Stop the worm's movement if the player is out of range
            rb.velocity = Vector2.zero;
            animator.SetBool("IsMoving", false);  // Assuming you have an animation parameter to control movement
        }
    }

    void MoveTowardsPlayer()
    {
        // Calculate the direction towards the player
        Vector2 direction = (player.position - transform.position).normalized;

        // Move the worm towards the player
        rb.velocity = direction * moveSpeed;

        // Set animation parameter to true to trigger movement animation
        animator.SetBool("IsMoving", true);  // Assuming you have an animation parameter to control movement

        // Optional: Flip the worm to face the player
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(8, 8, 8);
        }
        else
        {
            transform.localScale = new Vector3(-8, 8, 8);
        }
    }
}