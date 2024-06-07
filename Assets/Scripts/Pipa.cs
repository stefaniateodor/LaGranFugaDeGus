using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipa : MonoBehaviour
{
    Animator miAnimadorController; 
    private AudioSource audioSource;
    public AudioClip pickupSound;

    // Start is called before the first frame update
    void Start()
    {
       miAnimadorController = this.GetComponent<Animator>(); 
       audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

       void OnTriggerEnter2D(Collider2D col){
        if (col.name == "Gus"){
        GameManager.pipa += 1;
        miAnimadorController.SetBool("pipaDestruir",true);
        PlayPickupSound();
         Destroy(this.gameObject,0.3f);
        }
        
       }  
        void PlayPickupSound() // Add this method
    {
        if (pickupSound != null)
        {
            audioSource.PlayOneShot(pickupSound);
        }
    } 
}
