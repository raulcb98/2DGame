using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Defines the score pointer logic.
/// </summary>
public class Pointer : MonoBehaviour
{
    // Private attributes
    public Text pointerText;
    private int points;

    public void Start()
    {
        SetPoints(GameManager.points);
    }

    // Set points text value
    public void SetPoints(int points) 
    {
        this.points = points;
        pointerText.text = this.points.ToString("f0");
    }
}
