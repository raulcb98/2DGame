using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorReloj : MonoBehaviour
{
    public Text timeText;

    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        timeText.text = time.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        time = time + 1 * Time.deltaTime;
        timeText.text = time.ToString("f0");
    }
}
