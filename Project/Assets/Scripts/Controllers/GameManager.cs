using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager
{
    public static string activeGamePath;


    public static void NewGame(string gamePath)
    {
        activeGamePath = gamePath;
        SceneManager.LoadScene("Main");
    }

    public static void EndGame()
    {
        Restart();
    }


    // Load menu scene
    private static void Restart()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public static void LoadGame(string gamePath) 
    {
        activeGamePath = gamePath;
        SceneManager.LoadScene("Main");
    }
}
