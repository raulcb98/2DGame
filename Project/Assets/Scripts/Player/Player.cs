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

    // Private attributes
    Game_Manager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Game_Manager>();

        LoadData();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        gameManager.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            gameManager.EndGame();
        }
    }

    public void Takehealth(int health)
    {
        currentHealth += health;
        gameManager.SetHealth(currentHealth);

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
