using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SaveLevel(LevelState levelState) {

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "levelstate" + levelState.GetLevelNumber() + ".pop";
        FileStream stream = new FileStream(path, FileMode.Create);

        LevelData levelData = new LevelData(levelState);

        formatter.Serialize(stream, levelData);
        stream.Close();
    }

    public static LevelData LoadLevel(int levelToLoad) {

        string path = Application.persistentDataPath + "levelstate" + levelToLoad + ".pop";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LevelData levelData = formatter.Deserialize(stream) as LevelData;
            stream.Close();
            return levelData;
        }

        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
