using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDamage : MonoBehaviour
{
    // This method is called when a bullet impact to the enemy
    void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponentInChildren<Player>();

        if (player != null)
        {
            player.TakeDamage(1000);
        }
        
    }
}
