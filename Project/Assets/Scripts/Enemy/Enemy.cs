using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Define the basic attributes of an enemy.
/// </summary>
public class Enemy : MonoBehaviour
{ 
    // Public attributes
    public float health = 100f;
    public GameObject deathEffect;

    // Private attributes
    Game_Manager manager;


    // Start is called at first frame
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Game_Manager>();
    }


    // Decrease enemy health
    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }
    

    // Destroy the enemy
    void Die()
    {
        manager.IncreasePoints();
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


    // This method is called when a bullet impact to the enemy
    void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponentInChildren<Player>();

        if (player != null)
        {            
            player.TakeDamage(20);
        }
    }
}
