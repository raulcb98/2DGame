using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Manage Game elements like time, score, scene changes
/// and end game.
/// </summary>
public class Game_Manager : MonoBehaviour
{
    // Private variables
    Player player;
    //Timer timer;
    Pointer pointer;
    HealthBar healthBar;
    bool gameHasEnded = false;


    // Start is called before the first frame update 
    void Start()
    {
        GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //timer = mainCamera.GetComponentInChildren<Timer>();
        pointer = mainCamera.GetComponentInChildren<Pointer>();
        healthBar = mainCamera.GetComponentInChildren<HealthBar>();

        healthBar.SetMaxHealth(player.Max_Health);
    }


    // Finish the game
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Restart();
        }
    }


    // Load menu scene
    void Restart()
    {
        SceneManager.LoadScene("Menu");
    }


    // Update score pointer
    public void IncreasePointer(int increment)
    {
        pointer.IncreasePointer(increment);
    }

    public void SetHealth(int increment)
    {
        healthBar.SetHealth(increment);
    }
}
