using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionScript : MonoBehaviour
{
    // Start is called before the first frame update
   public string scene3; 
   private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("player"))
        {Debug.Log("Player entered the trigger zone");
            // Load the specified scene
            SceneManager.LoadScene(scene3); 
        }
    }
}

