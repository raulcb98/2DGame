using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class LoadGame_Menu : MonoBehaviour
{
    public GameObject gameButton1;
    public GameObject gameButton2;
    public GameObject gameButton3;

    private void Start()
    {
        EnableGameButtons();
    }

    private void EnableGameButtons()
    {
        if (File.Exists(PathManager.gamePath1))
        {
            gameButton1.GetComponent<Button>().enabled = true;
        }

        if (File.Exists(PathManager.gamePath2))
        {
            gameButton2.GetComponent<Button>().enabled = true;
        }

        if (File.Exists(PathManager.gamePath3))
        {
            gameButton3.GetComponent<Button>().enabled = true;
        }
    }

    public void LoadGame(int gameSlotId)
    {
        GameManager.LoadGame(PathManager.FindGamePathById(gameSlotId));
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void DeleteAllSavedGame()
    {
        if (File.Exists(PathManager.gamePath1))
        {
            File.Delete(PathManager.gamePath1);
            gameButton1.GetComponent<Button>().enabled = false;
        }

        if (File.Exists(PathManager.gamePath2))
        {
            File.Delete(PathManager.gamePath2);
            gameButton2.GetComponent<Button>().enabled = false;
        }

        if (File.Exists(PathManager.gamePath3))
        {
            File.Delete(PathManager.gamePath3);
            gameButton3.GetComponent<Button>().enabled = false;
        }
    }
}
