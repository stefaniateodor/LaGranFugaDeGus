using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovGus : MonoBehaviour
{

    private Rigidbody2D rb; 
    private Animator animatorController;
    public float velocidad = 5f;
    public float multiplicador = 5f;
    public float multiplicadorSalto = 5f;
    float movTeclas;
    private bool puedoSaltar = true;
    private bool activaSaltoFixed = false;
    public bool miraDerecha = true;
    GameObject respawn;
  
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animatorController = this.GetComponent<Animator>();
        respawn = GameObject.Find("Respawn");
        transform.position = respawn.transform.position;
        
    }

    // Update is called once per frame
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
    
    
    //ANIMATOR 
        if(movTeclas != 0){
            animatorController.SetBool("activaCamina", true);
        }else{
            animatorController.SetBool("activaCamina", false);
        }

    //SALTO
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f);
        Debug.DrawRay(transform.position, Vector2.down, Color.magenta);

        if(hit){
            puedoSaltar = true;
        }else{
            puedoSaltar = false;
        }

        if(Input.GetKeyDown(KeyCode.Space) && puedoSaltar){
            activaSaltoFixed = true;
            
        }

        if(transform.position.y <= -7){
            AudioManager.Instance.SonarClipUnaVez(AudioManager.Instance.fxDead);
            Respawnear();
        }

        if(GameManager.vidas <= 0)
        {
            GameManager.estoyMuerto = true;
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

    public void Respawnear(){

        Debug.Log("vidas: " +GameManager.vidas);
        GameManager.vidas = GameManager.vidas - 1;
        Debug.Log("vidas: " +GameManager.vidas);

        transform.position = respawn.transform.position;
   }
    
}
