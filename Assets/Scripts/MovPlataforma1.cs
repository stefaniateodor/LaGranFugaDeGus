using UnityEngine;

public class MovPlataforma1: MonoBehaviour
{
    public float speed = 2f; // Speed of the platform's movement
    public float upperBoundary = 5f; // Upper boundary for the platform's movement
    public float lowerBoundary = -5f; // Lower boundary for the platform's movement
    private bool movingUp = true; // Direction flag

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
            Debug.Log("Moving Up");
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("Moving Down");
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }

   private void CheckBoundaries()
    {
        // Log the current position for debugging
        Debug.Log("Current Y Position: " + transform.position.y);

        // Switch direction if the platform reaches the boundaries
        if (transform.position.y >= upperBoundary)
        {
            Debug.Log("Reached upper boundary. Switching to down.");
            movingUp = false;
        }
        else if (transform.position.y <= lowerBoundary)
        {
            Debug.Log("Reached lower boundary. Switching to up.");
            movingUp = true;
        }
    }
}
