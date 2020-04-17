using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

/// <summary>
/// Defines player attributes.
/// </summary>
public class Player : MonoBehaviour
{
    // Public attributes
    public int maxHealth = 100;
    public int currentHealth;
    public string playerName;

    // Private attributes
    HealthBar healthBar;
    PlayerMovement playerMovement;


    // Start is called before the first frame update
    void Start()
    {
        SettingsData settingsData = new SettingsData();
        if (settingsData != null)
        {
            maxHealth = settingsData.playerMaxHealth;
        }

        if (File.Exists(GameManager.activeGamePath))
        {
            LoadData();
        } else
        {
            playerName = GameManager.activePlayerName;
            currentHealth = maxHealth;
        }

        healthBar = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<HealthBar>();
        playerMovement = GetComponent<PlayerMovement>();

        healthBar.SetHealth(currentHealth);
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

        playerMovement.IsHurt(true);

        if (currentHealth <= 0)
        {
            GameManager.EndGame();
        }
    }

    private void LoadData()
    {
        PlayerData playerData = SaveSystem.Load<PlayerData>();
        if(playerData != null)
        {
            playerName = playerData.playerName;
            currentHealth = playerData.currentHealth;

            if (playerData.currentLevel.Equals(SceneManager.GetActiveScene().name)) {
                Vector3 position;
                position.x = playerData.position[0];
                position.y = playerData.position[1];
                position.z = playerData.position[2];
                transform.position = position;
            }

        }
    }
}
