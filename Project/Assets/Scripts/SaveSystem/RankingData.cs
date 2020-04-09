using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class RankingData 
{
    public int[] rankingPoints;
    
    public RankingData()
    {
        if (File.Exists(PathManager.rankingPath)) {
            RankingData data = SaveSystem.Load<RankingData>();
            rankingPoints = data.rankingPoints;
        } else
        {
            rankingPoints = new int[10];
            for(int i = 0; i < rankingPoints.Length; i++)
            {
                rankingPoints[i] = 0;
            }
        }
    }

    public void UpdateRanking(int points)
    {
        bool found = false;
        int i = 0;

        while(!found && i < rankingPoints.Length)
        {
            if(rankingPoints[i] < points)
            {
                rankingPoints[i] = points;
                found = true;
            }
            else
            {
                i++;
            }
        }
    }
}
