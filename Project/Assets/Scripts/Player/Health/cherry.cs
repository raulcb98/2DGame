using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cherry : MonoBehaviour
{
    public GameObject deathEffect;

    void OnTriggerEnter2D(Collider2D collision)
    {

        Player player = collision.GetComponentInChildren<Player>();

        if (collision.tag == "Player" && player != null)
        {
            player.Takehealth(10);
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
    }
}
