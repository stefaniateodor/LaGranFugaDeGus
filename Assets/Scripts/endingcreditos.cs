using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCreditsTrigger : MonoBehaviour
{
    public GameObject creditos; // Assign the GameObject holding the ending credits image in the inspector
      private void Start()
    {
        // Ensure the credits GameObject is inactive at the start
        creditos.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Activate the ending credits GameObject
            creditos.SetActive(true);
        }
    }
}

