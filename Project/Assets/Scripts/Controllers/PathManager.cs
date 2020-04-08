using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public static class PathManager 
{
    public static string gamePath1 = Application.persistentDataPath + "/game1.dat";
    public static string gamePath2 = Application.persistentDataPath + "/game2.dat";
    public static string gamePath3 = Application.persistentDataPath + "/game3.dat";

    //public static int gamePathId1 = 1;
    //public static int gamePathId2 = 2;
    //public static int gamePathId3 = 3;

    public static string getAvailableGamePath()
    {
        if (!File.Exists(gamePath1))
        {
            return gamePath1;
        }

        if (!File.Exists(gamePath2))
        {
            return gamePath2;
        }

        if (!File.Exists(gamePath3))
        {
            return gamePath3;
        }

        return null;
    }


    public static string FindGamePathById(int gamePathId)
    {
        switch (gamePathId)
        {
            case 1: return gamePath1;
            case 2: return gamePath2;
            case 3: return gamePath3;
            default: return null;
        }
    }
}
