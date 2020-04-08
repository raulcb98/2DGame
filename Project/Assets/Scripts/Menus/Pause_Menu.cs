using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Define the logic of the pause menu.
/// </summary>
public class Pause_Menu : MonoBehaviour
{
    // Public attributes.
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public Text saveCommitText;


    // Update is called once per frame.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }


    // Resume the game.
    public void Resume()
    {
        FindObjectOfType<AudioManager>().Play("PulseSound");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    

    // Pause the game.
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        saveCommitText.enabled = false;
    }


    public void LoadMenu()
    {
        FindObjectOfType<AudioManager>().Play("PulseSound");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }


    public void QuitGame()
    {
        //Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void SaveGame()
    {
        SaveSystem.SaveGame(0);
        saveCommitText.enabled = true;
    }
}


