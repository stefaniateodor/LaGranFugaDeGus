using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ratasaurio : MonoBehaviour
{
    GameObject personaje;
    Vector3 posicionInicial;
    public float velocidadFantasma = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position;
        personaje = GameObject.FindGameObjectWithTag("Player");

    
    }

    // Update is called once per frame
    void Update()
    {
            float distancia = Vector3.Distance(transform.position, personaje.transform.position);
        float velocidadFinal = velocidadFantasma * Time.deltaTime;

        
    }
}
