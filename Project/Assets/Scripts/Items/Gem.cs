using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines the behaviour of a gem.
/// </summary>
public class Gem : MonoBehaviour
{
    // This method is called when the player collide with a gem
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject manager = GameObject.FindGameObjectWithTag("GameManager");
            manager.GetComponent<Game_Manager>().IncreasePoints();
        }
    }
}
