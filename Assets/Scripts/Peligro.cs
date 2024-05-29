using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Peligro : MonoBehaviour
{
    // Called when the character enters a trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))
        {
            // Logic for what happens when the player collides with a spike
            Debug.Log("Player hit a spike!");
            // Add your logic here, e.g., reduce health, respawn, etc.
        }
    }

    // Called when the character collides with a non-trigger collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Spike"))
        {
            // Logic for what happens when the player collides with a spike
            Debug.Log("Player hit a spike!");
            // Add your logic here, e.g., reduce health, respawn, etc.
        }
    }
}