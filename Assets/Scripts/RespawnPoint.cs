using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
     public Transform respawnPoint;

    void Start()
    {
        // If you didn't assign the respawn point in the Inspector, you can find it by name.
        if (respawnPoint == null)
        {
            respawnPoint = GameObject.Find("respawnPoint").transform;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collides with a spike
        if (collision.gameObject.CompareTag("Spike"))
        {
            Respawn();
        }
    }

   
    void Respawn()
    {
        // Move the player to the respawn point
        transform.position = respawnPoint.position;
    }
}
