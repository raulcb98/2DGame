using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public float damage = 40f;
    public GameObject bulletImpactAnimation;

    int distanceDestroy = 12;

    Transform player;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void Update()
    {
        if(Mathf.Abs(rb.position.x - player.position.x) >= distanceDestroy)
        {
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponentInChildren<Enemy>();

        if(enemy != null)
        {
            if(enemy.getHealth() - damage <= 0)
            {
                Player_Health points = player.GetComponent<Player_Health>();
                points.IncreasePoints();
            }

            enemy.TakeDamage(damage);
        }

        Instantiate(bulletImpactAnimation, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
    
}
