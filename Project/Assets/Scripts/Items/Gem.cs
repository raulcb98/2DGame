using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines the behaviour of a gem.
/// </summary>
public class Gem : MonoBehaviour
{
    public int gemReward = 5;


    private void Start()
    {
        LoadData();
    }

    // This method is called when the player collide with a gem
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("CoinSound");
            GameManager.TakePoints(gemReward);
        }
    }


    private void LoadData()
    {
        SettingsData data = new SettingsData();
        if(data != null)
        {
            gemReward = data.gemPoints;
        }
    }
}
