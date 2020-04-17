using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
    // Player data
    public string playerName;
    public int currentHealth;
    public int points;
    public float[] position;

    public string currentLevel;

    public PlayerData()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        currentLevel = SceneManager.GetActiveScene().name;

        if (player != null)
        {
            playerName = player.playerName;
            currentHealth = player.currentHealth;
            points = GameManager.points;

            position = new float[3];
            position[0] = player.transform.position.x;
            position[1] = player.transform.position.y;
            position[2] = player.transform.position.z;
        }
        else
        {
            Debug.LogError("Unable to get Player data while saving game");
        }
    }
}
