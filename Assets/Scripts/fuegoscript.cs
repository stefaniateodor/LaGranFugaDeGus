using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuegoscript : MonoBehaviour
{ 
    GameObject gus;

    bool bolaDerecha = true;
    // Start is called before the first frame update
    void Start()
    {
       gus=GameObject.Find("Gus");
       bolaDerecha= gus.GetComponent<MovGus>().miraDerecha;
    }

    // Update is called once per frame
    void Update()
    {
       if ( bolaDerecha ){
         transform.Translate(0.002f,0,0); 
       }else  {
         transform.Translate(-0.002f,0,0); 
       }
      
    }
}
