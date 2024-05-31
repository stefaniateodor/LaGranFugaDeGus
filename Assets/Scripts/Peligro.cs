using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Peligro : MonoBehaviour
{
    // Called when the character enters a trigger collider
    public Transform RespawnPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the character collides with the spikes
        if (collision.CompareTag("Spike"))
        {
            // Move the character to the respawn point
            transform.position = RespawnPoint.position;
        }
    }

    // Called when the character collides with a non-trigger collider
   
}