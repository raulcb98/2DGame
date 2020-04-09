
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void Save<T>(T data)
    {
        string path = PathManager.SelectPath<T>();

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static T Load<T>()
    {
        string path = PathManager.SelectPath<T>();

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            T data = (T) formatter.Deserialize(stream);
            stream.Close();

            return data;
        } else
        {
            Debug.LogError("Save file not found in " + path);
            return default(T);
        }
    }
}
