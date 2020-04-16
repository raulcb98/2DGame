using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class Ranking_Menu : MonoBehaviour
{
    public Text rankingText;

    private void Start()
    {
        ShowRanking();
    }

    private void ShowRanking()
    {
        rankingText.text = "";

        RankingData ranking = new RankingData();

        int[] rankingPoints = ranking.rankingPoints;
        string[] rankingNames = ranking.rankingNames;

        string text = "";
        for(int i = 0; i < rankingPoints.Length; i++)
        {
            if (rankingPoints[i] >= 0)
            {
                text = "";
                text += i+1 + ".  " + rankingNames[i] + "  ";

                int numPoints = 30 - text.Length;
                for (int j = 0; j < numPoints; j++)
                {
                    text += ". ";
                }
                text += rankingPoints[i] + "\n";

                rankingText.text += text;
            }
        }
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
        FindObjectOfType<AudioManager>().Play("PulseSound");

        if (File.Exists(PathManager.rankingPath))
        {
            File.Delete(PathManager.rankingPath);
        }
        ShowRanking();
    }
   
    public void goMenu()
    {
        FindObjectOfType<AudioManager>().Play("PulseSound");

        SceneManager.LoadScene("MainMenu");
    }
}
