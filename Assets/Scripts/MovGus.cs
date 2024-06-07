using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovGus : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animatorController;

    public float velocidad = 7f;
    public float multiplicador = 4f;
    public float multiplicadorSalto = 5f;
    public float multiplicadorRayo = 4f;
    public bool miraDerecha = true;

    private bool puedoSaltar = true;
    private bool activaSaltoFixed = false;
    private float movTeclas;

    // Life system
    public int maxLives = 4;
    private int currentLives;
    public Image[] hearts;

    // Starting position
    private Vector3 startingPosition;

    // Game over UI
    public GameObject gameOverPanel;

    // Seed counter
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animatorController = GetComponent<Animator>();

        // Save the starting position
        startingPosition = transform.position;

        // Initialize lives and update UI
        currentLives = maxLives;
        UpdateHeartsUI();

        // Ensure game over panel is hidden at start
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        
    }

    void Update()
    {
        if (currentLives > 0)
        {
            // Handle movement
            movTeclas = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(movTeclas * multiplicador, rb.velocity.y);

            if (movTeclas < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                miraDerecha = false;
            }
            else if (movTeclas > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                miraDerecha = true;
            }

            // Handle animation
            animatorController.SetBool("activaCamina", movTeclas != 0);

            // Handle jumping
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, multiplicadorRayo);
            if (hit.collider != null)
            {
                puedoSaltar = true;
                Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
            }
            else
            {
                puedoSaltar = false;
                Debug.Log("Raycast did not hit anything.");
            }

            if (Input.GetKeyDown(KeyCode.Space) && puedoSaltar)
            {
                rb.AddForce(new Vector2(0, multiplicadorSalto), ForceMode2D.Impulse);
                Debug.Log("Jump");
            }
        }
    }

    void FixedUpdate()
    {
        if (activaSaltoFixed)
        {
            rb.AddForce(new Vector2(0, multiplicadorSalto), ForceMode2D.Impulse);
            activaSaltoFixed = false;
        }
    }

    // Handle collision with dangerous objects and seeds
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            HandleRespawn();
        }
        else if (collision.gameObject.CompareTag("Flag"))
        {
            LoadNextLevel();
        }
       
    }

    private void HandleRespawn()
    {
        if (currentLives > 0)
        {
            currentLives--;
            Debug.Log("Respawn! Lives left: " + currentLives);
            UpdateHeartsUI();
            transform.position = startingPosition; // Respawn at the starting position
        }
        else
        {
            Debug.Log("Game Over!");
            ShowGameOverScreen();
        }
    }

    private void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < currentLives;
        }
    }

    private void ShowGameOverScreen()
    {
        // Reset the velocity and disable character controls immediately
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;

        // Optionally, disable the Rigidbody2D to prevent any further movement
        rb.isKinematic = true;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        // Disable character controls
        enabled = false; // This will disable the MovGus script
    }

    private void LoadNextLevel()
    {
        // Load the next scene
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("You have completed all levels!");
        }
    }

    private void CollectSeed(GameObject seed)
    {
        seedCount++;
        UpdateSeedCounterUI();
        Destroy(seed);
    }

    private void UpdateSeedCounterUI()
    {
        if (seedCounterText != null)
        {
            seedCounterText.text = "Seeds: " + seedCount;
        }
    }

   
}
