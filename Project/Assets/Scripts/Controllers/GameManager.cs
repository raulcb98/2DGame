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
    public static string currentLevel;

    public static int points;
    public static int health;

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
        ranking.UpdateRanking(GameManager.points, player.playerName);
        SaveSystem.Save(ranking);
        points = 0;
        currentLevel = SceneManager.GetActiveScene().name;
        AudioManager.instance.StopPlaying(currentLevel + "_Sound");
        AudioManager.instance.Play("Menu_Sound");
        SceneManager.LoadScene("RankingMenu");
    }

    public static void LoadGame(string gamePath) 
    {
        activeGamePath = gamePath;
        PlayerData playerData = SaveSystem.Load<PlayerData>();
        points = playerData.points;
        currentLevel = playerData.currentLevel;
        SceneManager.LoadScene(currentLevel);
        AudioManager.instance.StopPlaying("Menu_Sound");
        AudioManager.instance.Play(currentLevel + "_Sound");
    }

    public static void LoadLevel(string level, string levelGo)
    {
        AudioManager.instance.StopPlaying(level + "_Sound");
        AudioManager.instance.Play(levelGo + "_Sound");
        SceneManager.LoadScene(levelGo);
        GameManager.currentLevel = SceneManager.GetActiveScene().name;
    }

    public static void TakePoints(int p)
    {
        Pointer pointer = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<Pointer>();
        points += p;
        pointer.SetPoints(points);
    }
}
