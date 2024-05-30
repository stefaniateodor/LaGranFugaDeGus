using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuegoscript : MonoBehaviour
{ 
    GameObject gus;

    bool bolaDerecha = true;
    float tiempoDestruccion=3.0f;
    public float speedBala=0.2f;
    float queHoraEs;
    // Start is called before the first frame update
    void Start()
    {
       gus=GameObject.Find("Gus");
       bolaDerecha= gus.GetComponent<MovGus>().miraDerecha;
       queHoraEs= Time.time;
    }

    // Update is called once per frame
    void Update()
    {
      if (bolaDerecha){
            transform.Translate(speedBala*Time.deltaTime,0,0,Space.World); 
        } else {
            transform.Translate((speedBala*Time.deltaTime)*-1,0,0,Space.World); 
        }


       if(Time.time>=queHoraEs+tiempoDestruccion){
        Destroy(this.gameObject);
       }
    }
     void OnTriggerEnter2D(Collider2D col){
    // Check if the collided object's name starts with "Cucaracha" or "Gusano"
    if (col.gameObject.name.StartsWith("Cucaracha") || col.gameObject.name.StartsWith("Gusano")){
        // Destroy the collided object
        Destroy(col.gameObject);

        // Destroy the object this script is attached to
        Destroy(this.gameObject);
    }
}

}
