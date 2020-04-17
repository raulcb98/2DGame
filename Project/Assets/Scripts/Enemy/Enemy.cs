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
    public int enemyDamage = 30;
    public int enemyDeathReward = 5;
    public float attackRate = 1.5f;
    public GameObject deathEffect;

    // Private attributes
    private float nextAttackTime = 0f;
    private bool rewarded = false;

    // Start is called at first frame
    void Start()
    {
        LoadData();
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
        if (!rewarded)
        {
            GameManager.TakePoints(enemyDeathReward);
            rewarded = true;
        }
        
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

    private void LoadData()
    {
        SettingsData data = new SettingsData();
        if(data != null)
        {
            health = data.enemyHealth;
            enemyDamage = data.enemyDamage;
            attackRate = data.enemyAttackRate;
            enemyDeathReward = data.enemyReward;
        }
    }

    public int CountEnemiesAtDistance(float distance)
    {
        Enemy[] allEnemies = FindObjectsOfType<Enemy>();
        int counter = 0;
        
        for(int i = 0; i < allEnemies.Length; i++)
        {
            if(Vector2.Distance(transform.position, allEnemies[i].transform.position) <= distance)
            {
                counter++;
            }
        }

        return counter - 1;
    }
}
