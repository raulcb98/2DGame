using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class GameOver_Menu : MonoBehaviour
{
    public Text rankingText;
    public Text nameRankingText;


    private void Start()
    {
        ShowRanking();
    }

    private void ShowRanking()
    {
        RankingData ranking = new RankingData();
        rankingText.text = "Ranking : " + arrayToString(ranking.rankingPoints);
        nameRankingText.text = "Name Ranking : " + arrayToString(ranking.rankingNames);
    }


    private string arrayToString<T>(T[] array)
    {
        string cad = "[";
        for (int i = 0; i < array.Length; i++)
        {
            cad += array[i].ToString();
            if (i + 1 < array.Length) cad += ", ";
        }
        cad += "]";

        return cad;
    }


    public void ResetRanking()
    {
        if (File.Exists(PathManager.rankingPath))
        {
            File.Delete(PathManager.rankingPath);
        }
        ShowRanking();
    }
   
    public void goMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
