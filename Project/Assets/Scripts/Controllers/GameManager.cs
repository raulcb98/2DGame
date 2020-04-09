using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager
{
    public static string activeGamePath;


    public static void NewGame(string gamePath)
    {
        activeGamePath = gamePath;
        SceneManager.LoadScene("Main");
    }

    public static void EndGame()
    {
        // Update ranking
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        RankingData ranking = new RankingData();
        ranking.UpdateRanking(player.points);
        SaveSystem.Save(ranking);

        SceneManager.LoadScene("GameOverMenu");
    }

    public static void LoadGame(string gamePath) 
    {
        activeGamePath = gamePath;
        SceneManager.LoadScene("Main");
    }
}
