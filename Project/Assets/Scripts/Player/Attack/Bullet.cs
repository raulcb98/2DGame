using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines the bullet uses by the player.
/// </summary>
public class Bullet : MonoBehaviour
{
    // Public attributes.
    public float speed = 20f;
    public Rigidbody2D rb;
    public float damage = 40f;
    public GameObject bulletImpactAnimation;

    // Private attributes.
    Transform player;
    int distanceDestroy = 12;


    // Start is called before the first frame update
    void Start()
    {
        // Bullet start at firepoint GameObject
        rb.velocity = transform.right * speed;

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    // Update is called once per frame
    void Update()
    {
        // Destroy the bullet after travel a defined distance
        if(Mathf.Abs(rb.position.x - player.position.x) >= distanceDestroy)
        {
            Destroy(gameObject);
        }
    }

    
    // This method is called when the bullet collided
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Damage the enemy
        Enemy enemy = collision.GetComponentInChildren<Enemy>();
        if(enemy != null)
        {   
            enemy.TakeDamage(damage);
        }

        // Destroy the bullet
        Instantiate(bulletImpactAnimation, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
