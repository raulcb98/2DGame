using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public GameObject deathEffect;

    public int Max_Health = 100;
    public int Current_Health;



    public HealthBar healthBar;

    public Game_Manager gameManager;



    
    // Start is called before the first frame update
    void Start()
    {
        Current_Health = Max_Health;
        healthBar.SetMaxHealth(Max_Health);
        
    }

    public void TakeDamage(int damage)
    {
        Current_Health -= damage;
        healthBar.SetHealth(Current_Health);

        if(Current_Health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            gameManager.EndGame();
        }

    }

    public void Takehealth(int health)
    {
        Current_Health += health;
        healthBar.SetHealth(Current_Health);

    }


}
