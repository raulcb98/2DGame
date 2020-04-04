using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health = 100f;
    public GameObject deathEffect;
    public Animator animator;

    // Update is called once per frame
    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public float getHealth() {
        return health;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponentInChildren<Player>();

        if (player != null)
        {            
            player.TakeDamage(20);
        }
    }
}
