using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines the behaviour of a gem.
/// </summary>
public class Gem : MonoBehaviour
{
    public int gemReward = 1;

    // This method is called when the player collide with a gem
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("CoinSound");
            GameObject manager = GameObject.FindGameObjectWithTag("GameManager");
            manager.GetComponent<Game_Manager>().IncreasePointer(gemReward);
        }
    }
}
