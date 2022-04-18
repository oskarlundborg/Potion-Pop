using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveSystem 
{
    public static void SavePlayer(GameState stateOfGame) {

        BinaryFormatter formatter = new BinaryFormatter();
        //sparfil + location till filen (som gives a path to a data directory )
        string path = Application.persistentDataPath + "/stateOfGame.saveFile";
        FileStream stream = new FileStream(path, FileMode.Create);
        //GameStateData gameData = new GameStateData();
    }
}
