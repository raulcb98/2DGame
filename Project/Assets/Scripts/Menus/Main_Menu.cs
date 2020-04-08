using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;


/// <summary>
/// Define the logic of the main menu.
/// </summary>
public class Main_Menu : MonoBehaviour
{

    // Load the game scene.
    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Play("PulseSound");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void ShowOptionsMenu()
    {
        FindObjectOfType<AudioManager>().Play("PulseSound");
        SceneManager.LoadScene("OptionsMenu");
    }


    public void ShowLoadGameMenu()
    {
        FindObjectOfType<AudioManager>().Play("PulseSound");
        SceneManager.LoadScene("LoadGameMenu");
    }

    // Close the game.
    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("PulseSound");
        //Debug.Log("QUIT!");
        Application.Quit();
    }
}
