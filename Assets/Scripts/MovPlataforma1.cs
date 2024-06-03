using UnityEngine;

public class MovPlataforma1: MonoBehaviour
{
     public float speed = 2f; // Speed of the platform's movement
    public float upperBoundary = 1f; // Upper boundary for the platform's movement
    public float lowerBoundary = -1f; // Lower boundary for the platform's movement
    private bool movingUp = true; // Direction flag

    private void Start()
    {
        // Ensure the initial position is within the boundaries
        if (transform.position.y > upperBoundary)
        {
            transform.position = new Vector3(transform.position.x, upperBoundary, transform.position.z);
        }
        else if (transform.position.y < lowerBoundary)
        {
            transform.position = new Vector3(transform.position.x, lowerBoundary, transform.position.z);
        }
    }

    private void Update()
    {
        Move();
        CheckBoundaries();
    }

    private void Move()
    {
        // Move the platform up or down based on the direction flag
        if (movingUp)
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
        // Switch direction if the platform reaches the boundaries
        if (transform.position.y >= upperBoundary)
        {
            movingUp = false;
        }
        else if (transform.position.y <= lowerBoundary)
        {
            movingUp = true;
        }
    }
}
