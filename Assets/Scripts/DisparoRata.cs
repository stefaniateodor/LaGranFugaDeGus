using UnityEngine;

public class DisparoRata : MonoBehaviour
{
    public GameObject moco; 
    public Transform firePoint; 
    public float projectileSpeed = 10f;
    public float fireRate = 2f; // Time between shots
    private Transform player;
    private float nextFireTime = 3.0f;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; 
    }

    void Update()
{
    Debug.Log("Update() called.");
    if (Time.time >= nextFireTime)
    {
        Debug.Log("Shoot() called.");
        Shoot();
        nextFireTime = Time.time + fireRate; 
    }
}

    void Shoot()
    {
        Vector3 direction = (player.position - firePoint.position).normalized;
        GameObject projectile = Instantiate(moco, firePoint.position, Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = direction * projectileSpeed;
        Destroy(projectile, 3f); 
    }
}


