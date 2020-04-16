using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseSound : MonoBehaviour
{
     public void Play()
     {
        AudioManager.instance.Play("PulseSound");

     }
}
