using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines the behaviour of a basic item.
/// </summary>
public class Item : MonoBehaviour
{
    // Public attributes
    public GameObject deathEffect;


    // Destroy the object with an animation
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
