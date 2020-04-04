using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    bool gameHasEnded = false;
    private int points = 0;
    public Text pointsText;

    public Text timeText;

    private float time = 0;

    void Start()
    {
        pointsText.text = points.ToString();
        timeText.text = time.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        time = time + 1 * Time.deltaTime;
        timeText.text = time.ToString("f0");
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Restart();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("Menu");
    }

    public void IncreasePoints()
    {
        points++;
        pointsText.text = points.ToString();
    }
}
