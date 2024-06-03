using UnityEngine;

public class MovGusano : MonoBehaviour
{
    public float speed = 3f; // Speed of the worm's movement
    public float forwardBoundary = 8f; // Forward boundary for the worm's movement
    public float backwardBoundary = -8f; // Backward boundary for the worm's movement
    public float detectionRange = 7f; // Range within which the worm detects the player
    public Transform player; // Reference to the player's transform

    private bool movingForward = true; // Direction flag

    private void Update()
    {
        Move();
        CheckBoundaries();
    }

    private void Move()
    {
        // Move the worm forward or backward based on the direction flag
        if (movingForward)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }

    private void CheckBoundaries()
    {
        // Switch direction if the worm reaches the boundaries
        if (transform.position.y >= forwardBoundary)
        {
            movingForward = false;
        }
        else if (transform.position.y <= backwardBoundary)
        {
            movingForward = true;
        }
    }

    private void FixedUpdate()
    {
        // Check if the player is within the detection range
        if (player != null && Vector2.Distance(transform.position, player.position) <= detectionRange)
        {
            // Calculate the direction towards the player
            Vector2 direction = (player.position - transform.position).normalized;

            // Move the worm towards the player
            transform.Translate(direction * speed * Time.fixedDeltaTime);
        }
    }
}
