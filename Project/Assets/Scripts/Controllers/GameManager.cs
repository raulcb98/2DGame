using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager
{
    public static string activeGamePath;
    public static string activePlayerName;

    public static void NewGame(string gamePath, string playerName)
    {
        activeGamePath = gamePath;
        activePlayerName = playerName;

        SceneManager.LoadScene("Main");
    }

    public static void EndGame()
    {
        // Update ranking
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        RankingData ranking = new RankingData();
        ranking.UpdateRanking(player.points, player.playerName);
        SaveSystem.Save(ranking);

        SceneManager.LoadScene("RankingMenu");
    }

    public static void LoadGame(string gamePath) 
    {
        activeGamePath = gamePath;
        SceneManager.LoadScene("Main");
    }
}
