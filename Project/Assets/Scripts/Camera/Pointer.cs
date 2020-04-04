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
    private Text pointerText;
    private int points;


    // Start is called before the first frame update
    void Start()
    {
        pointerText = GetComponent<Text>();
        pointerText.text = "0";
    }

    // Increase pointer score
    public void IncreasePointer(int increment)
    {
        points += increment;
        pointerText.text = points.ToString("f0");
    }
}
