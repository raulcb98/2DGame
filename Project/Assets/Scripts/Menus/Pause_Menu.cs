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
    public Button saveButton;


    private void Start()
    {
        if(GameManager.activeGamePath == null)
        {
            saveButton.enabled = false;
        }
    }

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
        SceneManager.LoadScene("MainMenu");
        FindObjectOfType<AudioManager>().StopPlaying("Level1_Sound");
        FindObjectOfType<AudioManager>().Play("Menu_Sound");
    }


    public void QuitGame()
    {
        //Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void SaveGame()
    {
        FindObjectOfType<AudioManager>().Play("PulseSound");

        SaveSystem.Save(new PlayerData());
        saveCommitText.enabled = true;
    }
}


