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
  
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animatorController = this.GetComponent<Animator>();
        
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
