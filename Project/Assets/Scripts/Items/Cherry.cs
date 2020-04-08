using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines a fruit to recover health.
/// </summary>
public class Cherry : MonoBehaviour
{
    // Public attributes
    public int healthValue = 10;


    // This method is called when the player collide with the fruit.
    void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponentInChildren<Player>();

        if (collision.tag == "Player" && player != null)
        {
            FindObjectOfType<AudioManager>().Play("CherrySound");
            player.TakeHealth(healthValue);
        }
    }
}
