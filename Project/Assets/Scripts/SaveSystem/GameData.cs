using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    // Player data
    public int currentHealth;
    public float[] position;

    // Game Manager data
    public int gemCounter;

    public GameData()
    {
        GetPlayerData();
        GetGameManagerData();
    }

    private void GetPlayerData()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if (player != null)
        {
            currentHealth = player.currentHealth;

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


    private void GetGameManagerData()
    {
        Game_Manager manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Game_Manager>();

        if(manager != null)
        {
            gemCounter = manager.GetGemsCounter();
        } else
        {
            Debug.LogError("Unable to get Game Manager data while saving game");
        }
    }
}
