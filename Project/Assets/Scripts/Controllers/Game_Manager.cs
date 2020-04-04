using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Manage Game elements like time, score, scene changes
/// and end game.
/// </summary>
public class Game_Manager : MonoBehaviour
{
    // Public variables
    public Text pointsText;
    public Text timeText;

    // Private variables
    int points = 0;
    float time = 0;
    bool gameHasEnded = false;


    // Start is called before the first frame update 
    void Start()
    {
        // Initialize point text and score text to 0
        pointsText.text = points.ToString();
        timeText.text = time.ToString();
    }


    // Update is called once per frame
    void Update()
    { 
        // Update time
        time = time + 1 * Time.deltaTime;
        timeText.text = time.ToString("f0");
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


    // Update score by one
    public void IncreasePoints()
    {
        points++;
        pointsText.text = points.ToString();
    }
}
