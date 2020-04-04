using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines a class to remove animations already displayed.
/// </summary>
public class Animation_Controller : MonoBehaviour
{

    // Destroy the GameObject associated with the animation
    public void finishAnimation()
    {
        Destroy(gameObject);
    }
}
