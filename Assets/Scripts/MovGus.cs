using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovGus : MonoBehaviour
{
    private Rigidbody2D rb; 
    private AudioSource audioSource;
    private Animator animatorController;

    public float velocidad = 7f;
    public float multiplicador = 4f;
    public float multiplicadorSalto = 5f;
    public float multiplicadorRayo = 4f;
    public bool miraDerecha = true;

    private bool puedoSaltar = true;
    private bool activaSaltoFixed = false;
    float movTeclas;

    // Life system
    public int maxLives = 4;
    private int currentLives;
    public Image[] hearts;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animatorController = this.GetComponent<Animator>();

        currentLives = maxLives;
        UpdateHeartsUI();
    }

    void Update()
    {
        // Handle movement
        movTeclas = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movTeclas * multiplicador, rb.velocity.y);

        if (movTeclas < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            miraDerecha = false;
        }
        else if (movTeclas > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
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

    void FixedUpdate()
    {
        if (activaSaltoFixed)
        {
            rb.AddForce(new Vector2(0, multiplicadorSalto), ForceMode2D.Impulse);
            activaSaltoFixed = false;
        }
    }

    // Handle collision with dangerous objects
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            HandleRespawn();
        }
    }

    private void HandleRespawn()
    {
        if (currentLives > 0)
        {
            currentLives--;
            Debug.Log("Respawn! Lives left: " + currentLives);
            UpdateHeartsUI();
            transform.position = Vector3.zero; // Example respawn position
        }
        else
        {
            Debug.Log("Game Over!");
            // Handle game over logic (disable player controls, show game over screen, etc.)
        }
    }

    private void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < currentLives;
        }
    }
}
