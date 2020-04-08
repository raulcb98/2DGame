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
    //Player player;

    //timer timer;
    //pointer pointer;
    //healthbar healthbar;

    //private float time = 0;
    //private int points = 0;

    //bool gameHasEnded = false;


    // Start is called before the first frame update 
    void Start()
    {
        //GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        //timer = mainCamera.GetComponentInChildren<Timer>();
        //pointer = mainCamera.GetComponentInChildren<Pointer>();
        //healthBar = mainCamera.GetComponentInChildren<HealthBar>();

        //healthBar.SetMaxHealth(player.maxHealth);

        //LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        //time = time + 1 * Time.deltaTime;
        //timer.SetTime(time);
    }

    // Finish the game
    public void EndGame()
    {
        Restart();
    }


    // Load menu scene
    void Restart()
    {
        SceneManager.LoadScene("Menu");
    }


    // Update score pointer
    //public void IncreasePointer(int increment)
    //{
    //    points += increment;
    //    pointer.setPoints(points);
    //}

    //public void SetHealth(int increment)
    //{
    //    healthBar.SetHealth(increment);
    //}

    //public int GetGemsCounter()
    //{
    //    return points;
    //}

    //private void LoadData()
    //{
    //    GameData gameData = SaveSystem.LoadGame(0);
    //    if(gameData != null)
    //    {
    //        points = gameData.gemCounter;
    //    }
    //}
}
