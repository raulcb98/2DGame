
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveGame()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = FindPathById(GameManager.activeGameSlot);
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData();
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadGame()
    {
        string path = FindPathById(GameManager.activeGameSlot);
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;
        } else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    private static string FindPathById(int gameSlot)
    {
        switch (gameSlot)
        {
            case 1: return Constants.GAMEPATH1;
            case 2: return Constants.GAMEPATH2;
            case 3: return Constants.GAMEPATH3;
            default: return null;
        }
    }
}
