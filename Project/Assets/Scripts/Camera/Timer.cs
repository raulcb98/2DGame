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
    private float time = 0;
    private Text timeText;

    
    // Start is called once at first frame
    void Start()
    {
        timeText = GetComponent<Text>();
    }


    // Update is called once per frame
    void Update()
    {
        // Update time
        time = time + 1 * Time.deltaTime;
        timeText.text = time.ToString("f0");
    }


    // Return current timer value
    public float getTime()
    {
        return time;
    }
}
