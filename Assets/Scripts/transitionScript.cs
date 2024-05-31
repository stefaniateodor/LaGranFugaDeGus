using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionScript : MonoBehaviour
{
    // Start is called before the first frame update
   public string sceneToLoad; 

   void Start()
{
    Debug.Log("transitionScript has started.");
}
   private void OnTriggerEnter2D (Collider2D other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {Debug.Log("Player entered the trigger zone");
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad); 
        }
    }
}

