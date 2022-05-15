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
            Debug.LogError("NOOOOO </3 Save file not found in " + path);
            return null;
        }
    }

    public static void SaveGameData(GameState gameState) 
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "gamestate.pop";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData gameData = new GameData(gameState);

        formatter.Serialize(stream, gameData);
        stream.Close();

    }
    public static GameData LoadGameData() {
        string path = Application.persistentDataPath + "gamestate.pop";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData gameData = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return gameData;
        }
        else 
        {
            Debug.LogError("NOOOOO </3 Save file not found in " + path);
            return null;
        }
    }

}
