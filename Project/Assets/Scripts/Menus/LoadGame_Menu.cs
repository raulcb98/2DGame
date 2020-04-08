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

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void EnableGameButtons()
    {
        if (File.Exists(Constants.GAMEPATH1)) {
            gameButton1.GetComponent<Button>().enabled = true;
        }

        if (File.Exists(Constants.GAMEPATH2)) {
            gameButton2.GetComponent<Button>().enabled = true;
        }

        if (File.Exists(Constants.GAMEPATH3)) {
            gameButton3.GetComponent<Button>().enabled = true;
        }
    }
}
