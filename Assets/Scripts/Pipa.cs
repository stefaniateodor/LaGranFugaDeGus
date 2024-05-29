using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipa : MonoBehaviour
{
    Animator miAnimadorController; 

    // Start is called before the first frame update
    void Start()
    {
       miAnimadorController = this.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

       void OnTriggerEnter2D(Collider2D col){
        if (col.name == "Gus"){
        GameManager.pipa += 1;
        miAnimadorController.SetBool("pipaDestruir",true);
         Destroy(this.gameObject,1f);
        }
        
      /* if (col.name == "Gus"){
        GameManager.pipa += 1;
        
        Destroy(this.gameObject,1f);
       }
   */ }   
}
