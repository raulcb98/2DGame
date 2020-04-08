using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using UnityEngine.UI;

/// <summary>
/// Define the logic of the main menu.
/// </summary>
public class Main_Menu : MonoBehaviour
{
    public Button newGameButton;

    private void Start()
    {
        if(PathManager.getAvailableGamePath() == null)
        {
            newGameButton.GetComponent<Button>().enabled = false;
        }
    }

    // Load the game scene.
    public void NewGame()
    {
        FindObjectOfType<AudioManager>().Play("PulseSound");
        GameManager.NewGame(PathManager.getAvailableGamePath());
        //SceneManager.LoadScene("Main");
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
