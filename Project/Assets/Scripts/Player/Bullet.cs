using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public float damage = 40f;
    public GameObject bulletImpactAnimation;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponentInChildren<Enemy>();

        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Instantiate(bulletImpactAnimation, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
    
}
