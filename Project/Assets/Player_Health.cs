using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public int Max_Health = 100;
    public int Current_Health;

    public HealthBar healthBar;
    
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
    }
}
