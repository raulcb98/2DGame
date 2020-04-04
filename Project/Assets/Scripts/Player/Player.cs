using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines player attributes.
/// </summary>
public class Player : MonoBehaviour
{
    // Public attributes
    public int Max_Health = 100;
    public int Current_Health;
    public HealthBar healthBar;

    // Private attributes
    Game_Manager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        Current_Health = Max_Health;
        healthBar.SetMaxHealth(Max_Health);

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Game_Manager>();
    }

    public void TakeDamage(int damage)
    {
        Current_Health -= damage;
        healthBar.SetHealth(Current_Health);

        if(Current_Health <= 0)
        {
            gameManager.EndGame();
        }
    }

    public void Takehealth(int health)
    {
        Current_Health += health;
        healthBar.SetHealth(Current_Health);

    }


}
