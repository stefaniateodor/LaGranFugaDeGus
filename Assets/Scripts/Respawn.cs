using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    // Start is called before the first frame update
     public Transform respawnPoint; // Reference to the respawn point

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the character collides with the spikes
        if (collision.CompareTag("Spikes"))
        {
            // Move the character to the respawn point
            transform.position = respawnPoint.position;
        }
    }
    
}
