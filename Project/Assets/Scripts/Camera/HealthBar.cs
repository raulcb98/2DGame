using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Defines the player health bar.
/// </summary>
public class HealthBar : MonoBehaviour
{
    // Public attributes
    public Slider slider;
    public Gradient gradient;
    public Image fill;


    // Set the max value of the health. 
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }


    // Set slider health value.
    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
