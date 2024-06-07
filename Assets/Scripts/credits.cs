using UnityEngine;
using UnityEngine.SceneManagement;

public class credits : MonoBehaviour
{
    public string endingCreditsSceneName = "creditos"; // Name of the ending credits scene

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Load the ending credits scene
            SceneManager.LoadScene(endingCreditsSceneName);
        }
    }
}

