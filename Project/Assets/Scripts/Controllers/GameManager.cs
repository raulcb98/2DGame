using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using UnityEngine.UI;

public static class GameManager
{
    public static string activeGamePath;
    public static string activePlayerName;

    public static void NewGame(string gamePath, string playerName)
    {
        activeGamePath = gamePath;
        activePlayerName = playerName;
        AudioManager.instance.StopPlaying("Menu_Sound");
        AudioManager.instance.Play("Level1_Sound");
        SceneManager.LoadScene("Level1");
    }

    public static void EndGame()
    {
        // Update ranking
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        RankingData ranking = new RankingData();
        ranking.UpdateRanking(player.points, player.playerName);
        SaveSystem.Save(ranking);
        AudioManager.instance.StopPlaying("Level1_Sound");
        AudioManager.instance.Play("Menu_Sound");
        SceneManager.LoadScene("RankingMenu");
    }

    public static void LoadGame(string gamePath) 
    {
        activeGamePath = gamePath;
        SceneManager.LoadScene("Level1");
    }

    public static void LoadLevel(string level, string levelGo)
    {
        AudioManager.instance.StopPlaying(level + "_Sound");
        AudioManager.instance.Play(levelGo + "_Sound");
        SceneManager.LoadScene(levelGo);
    }
}
