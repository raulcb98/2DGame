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
    public GameObject warningText;
    public InputField playerNameInputField;

    private void Start()
    {
        if(PathManager.getAvailableGamePath() == null)
        {
            warningText.SetActive(true);
        }
    }

    // Load the game scene.
    public void NewGame()
    {
        string playerName = playerNameInputField.text;
        if (playerName.Length > 0)
        {
            FindObjectOfType<AudioManager>().Play("PulseSound");
            GameManager.NewGame(PathManager.getAvailableGamePath(), playerName);
            //SceneManager.LoadScene("Main");
        }

    }

    public void ShowRankingMenu()
    {
        FindObjectOfType<AudioManager>().Play("PulseSound");
        SceneManager.LoadScene("RankingMenu");
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
