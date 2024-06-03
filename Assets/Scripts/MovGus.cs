using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovGus : MonoBehaviour
{

    private Rigidbody2D rb; 
     private AudioSource audioSource;
    private Animator animatorController;
     public AudioClip walkSound; 
    public AudioClip jumpSound;
    public float velocidad = 5f;
    public float multiplicador = 5f;
    public float multiplicadorSalto = 5f;
    public float multiplicadorRayo = 2f;
    float movTeclas;
    private bool puedoSaltar = true;
    private bool activaSaltoFixed = false;
    public bool miraDerecha = true;
  

   


  
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animatorController = this.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = false;
       
        audioSource.clip = walkSound; 
    }

    
    void Update()
    {
          //MOVIMIENTO 
        float movTeclas = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movTeclas*multiplicador, rb.velocity.y);

   

        if (movTeclas < 0){
            this.GetComponent<SpriteRenderer>().flipX = true;  
            miraDerecha = false;      
        }else if (movTeclas > 0){       
    
            this.GetComponent<SpriteRenderer>().flipX = false;  
            miraDerecha = true;      
        }
       
       // Play walking sound if moving horizontally and not already playing
        if (movTeclas != 0 && rb.velocity.y == 0 && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        // Stop walking sound if not moving horizontally
        else if (movTeclas == 0 && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
       
    
    
    //ANIMATOR 
        if(movTeclas != 0){
            animatorController.SetBool("activaCamina", true);
        }else{
            animatorController.SetBool("activaCamina", false);
        }

    //SALTO

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, multiplicadorRayo);
    
        Debug.Log("salto!" + hit.collider.gameObject.name);
        if (hit){
            puedoSaltar=true;
        //Debug.Log(hit.collider.name); 
        
        }else{
            puedoSaltar=false;
        }

        //salto
        if (Input.GetKeyDown(KeyCode.Space) && puedoSaltar)
{
    // Jump
    rb.AddForce(new Vector2(0, multiplicadorSalto), ForceMode2D.Impulse);
}

           
        
       

       


      
    }
    void FixedUpdate(){

        if(activaSaltoFixed == true){
             rb.AddForce(
                new Vector2(0,multiplicadorSalto),
                ForceMode2D.Impulse
            );
            activaSaltoFixed = false;
        }
       

    }


    
} 
