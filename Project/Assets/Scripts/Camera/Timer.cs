using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Defines the timer logic.
/// </summary>
public class Timer : MonoBehaviour
{
    // Private attributes
    private Text timeText;

    
    // Start is called once at first frame
    void Start()
    {
        timeText = GetComponent<Text>();
        timeText.text = "0";
    }


    // Set time text value
    public void SetTime(float time)
    {
        timeText.text = time.ToString("f0");
    }

}
