using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver_Menu : MonoBehaviour
{
    public Text rankingText;


    private void Start()
    {
        ShowRanking();
    }

    private void ShowRanking()
    {
        RankingData ranking = new RankingData();
        int[] rankingPoints = ranking.rankingPoints;

        string cad = "[";
        for(int i = 0; i < rankingPoints.Length; i++)
        {
            cad += rankingPoints[i].ToString();
            if (i + 1 < rankingPoints.Length) cad += ", ";
        }
        cad += "]";

        rankingText.text = rankingText.text + " : " + cad;
    }
   
    public void ShowMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
