using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlataform : MonoBehaviour
{
 public float speed = 2f;          // Speed of the platform
    public float leftBound = -1f;    // Left boundary for the platform
    public float rightBound = 1f;    // Right boundary for the platform

    private Vector3 direction = Vector3.left;

    void Update()
    {
        // Move the platform
        transform.Translate(direction * speed * Time.deltaTime);

        // Check if the platform has reached the left boundary
        if (transform.position.x <= leftBound)
        {
            direction = Vector3.right; // Change direction to right
        }
        // Check if the platform has reached the right boundary
        else if (transform.position.x >= rightBound)
        {
            direction = Vector3.left; // Change direction to left
        }
    }
}
