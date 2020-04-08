using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager
{
    public static int gameSlot;


    public static void EndGame()
    {
        Restart();
    }


    // Load menu scene
    private static void Restart()
    {
        SceneManager.LoadScene("Menu");
    }
}
