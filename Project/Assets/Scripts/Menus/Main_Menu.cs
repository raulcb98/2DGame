using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Define the logic of the main menu.
/// </summary>
public class Main_Menu : MonoBehaviour
{

    // Load the game scene.
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    // Close the game.
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
