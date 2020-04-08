using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    // Player data
    public int currentHealth;
    public float[] position;

    public PlayerData()
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
}
