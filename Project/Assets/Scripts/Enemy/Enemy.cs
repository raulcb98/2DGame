using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Define the basic attributes of an enemy.
/// </summary>
public class Enemy : MonoBehaviour
{ 
    // Public attributes
    public int health = 100;
    public int enemyDamage = 20;
    public GameObject deathEffect;
    public float attackRate = 1f;

    float nextAttackTime = 0f;

    // Private attributes
    Player player;
    int enemyDeathReward = 1;


    // Start is called at first frame
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    // Decrease enemy health
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }
    

    // Destroy the enemy
    void Die()
    {
        player.TakePoints(enemyDeathReward);
        FindObjectOfType<AudioManager>().Play("DeathEnemy");
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


    // This method is called when a bullet impact to the enemy
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + 1 / attackRate;
            Player player = collision.GetComponentInChildren<Player>();

            if (player != null)
            {
                player.TakeDamage(enemyDamage);
            }
        }
    }
}
