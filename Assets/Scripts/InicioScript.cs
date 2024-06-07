using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class InicioScript : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer component

    public void OnStartButtonClick()
    {
        if (videoPlayer != null)
        {
            videoPlayer.Play();
        }
    }

    private GameObject panelSettings;

    // Start is called before the first frame update
    void Start()
    {
        panelSettings = GameObject.Find("PanelSettings");
        panelSettings.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("1_tutorial");
    }
    
    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
    
    public void MostrarSettings()
    {
        panelSettings.SetActive(true);
    }

    public void OcultarSettings()
    {
        panelSettings.SetActive(false);
    }
}
