using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        currentHealth = maxHealth;
        healthBar = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<HealthBar>();
        pointer = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<Pointer>();

        //LoadData();
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
        GameData gameData = SaveSystem.LoadGame();
        if(gameData != null)
        {
            currentHealth = gameData.currentHealth;

            Vector3 position;
            position.x = gameData.position[0];
            position.y = gameData.position[1];
            position.z = gameData.position[2];
            transform.position = position;
        }
    }
}
