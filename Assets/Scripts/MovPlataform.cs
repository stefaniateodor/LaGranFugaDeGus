using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlataform : MonoBehaviour
{

    public Transform PointA; // Primer punto de destino
    public Transform PointB; // Segundo punto de destino
    public float speed = 2f; // Velocidad de la plataforma
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        target = PointB.position;
    }

    // Update is called once per frame
    void Update()
    {
          MovePlatform();
    }

    void MovePlatform()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = target == PointA.position ? PointB.position : PointA.position;
        }
        
        
    }
}
