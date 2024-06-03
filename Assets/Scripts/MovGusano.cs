using UnityEngine;

public class MovGusano : MonoBehaviour
{
    public float speed = 2f; // Speed of the worm's movement
    public float leftBoundary = -5f; // Left boundary for the worm's movement
    public float rightBoundary = 5f; // Right boundary for the worm's movement
    private bool movingRight = true; // Direction flag

    private void Update()
    {
        Move();
        CheckBoundaries();
    }

    private void Move()
    {
        // Move the worm left or right based on the direction flag
        if (movingRight)
        {
            Debug.Log("Moving Right");
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("Moving Left");
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    private void CheckBoundaries()
    {
        // Switch direction if the worm reaches the boundaries
        if (transform.position.x >= rightBoundary)
        {
            Debug.Log("Reached right boundary. Switching to left.");
            movingRight = false;
        }
        else if (transform.position.x <= leftBoundary)
        {
            Debug.Log("Reached left boundary. Switching to right.");
            movingRight = true;
        }
    }
}
