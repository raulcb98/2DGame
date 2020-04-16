using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class LoadGame_Menu : MonoBehaviour
{
    public Button gameButton1;
    public Button gameButton2;
    public Button gameButton3;

    public Button deleteButton1;
    public Button deleteButton2;
    public Button deleteButton3;

    private void Start()
    {
        EnableGameButtons();
    }

    private void EnableGameButtons()
    {
        if (File.Exists(PathManager.gamePath1))
        {
            gameButton1.enabled = true;
            deleteButton1.enabled = true;
        }

        if (File.Exists(PathManager.gamePath2))
        {
            gameButton2.enabled = true;
            deleteButton2.enabled = true;
        }

        if (File.Exists(PathManager.gamePath3))
        {
            gameButton3.enabled = true;
            deleteButton3.enabled = true;
        }
    }

    public void LoadGame(int gameSlotId)
    {
        FindObjectOfType<AudioManager>().Play("PulseSound");
        GameManager.LoadGame(PathManager.FindGamePathById(gameSlotId));
    }

    public void Back()
    {
        FindObjectOfType<AudioManager>().Play("PulseSound");
        SceneManager.LoadScene("MainMenu");
    }

    public void DeleteSaveGame(int id)
    {
        FindObjectOfType<AudioManager>().Play("PulseSound");

        switch (id)
        {
            case 1:
                {
                    File.Delete(PathManager.gamePath1);
                    gameButton1.enabled = false;
                    deleteButton1.enabled = false;
                } break;

            case 2:
                {
                    File.Delete(PathManager.gamePath2);
                    gameButton2.enabled = false;
                    deleteButton2.enabled = false;
                } break;

            case 3:
                {
                    File.Delete(PathManager.gamePath3);
                    gameButton3.enabled = false;
                    deleteButton3.enabled = false;
                } break;
        }
    }
}
