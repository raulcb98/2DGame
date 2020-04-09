using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// Defines player attributes.
/// </summary>
public class Player : MonoBehaviour
{
    // Public attributes
    public int maxHealth = 100;
    public int currentHealth;
    public int points = 0;

    // Private attributes
    HealthBar healthBar;
    Pointer pointer;


    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(GameManager.activeGamePath))
        {
            LoadData();
        } else
        {
            currentHealth = maxHealth;
        }

        healthBar = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<HealthBar>();
        pointer = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<Pointer>();

        healthBar.SetHealth(currentHealth);
        pointer.SetPoints(points);
    }
    
    public void TakeHealth(int health)
    {
        currentHealth += health;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthBar.SetHealth(currentHealth);
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            GameManager.EndGame();
        }
    }


    public void TakePoints(int points)
    {
        this.points += points;
        pointer.SetPoints(this.points);
    }


    public void SpendPoints(int spend)
    {
        points -= spend;
        pointer.SetPoints(points);
    }


    private void LoadData()
    {
        PlayerData playerData = SaveSystem.Load<PlayerData>();
        if(playerData != null)
        {
            currentHealth = playerData.currentHealth;
            points = playerData.points;

            Vector3 position;
            position.x = playerData.position[0];
            position.y = playerData.position[1];
            position.z = playerData.position[2];
            transform.position = position;
        }
    }
}
