using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private LevelData[] levelDataArray = new LevelData[9];
    private GameData gameData;
    private int totalAmountOfStars;
    private int latestUnlockedLevel;

    void Start()
    {
        ImportLevelData();
        //Get total number of unlocked stars
        //Get latest unlocked level number
    }

    private void ImportLevelData()
    {
        for(int i = 0; i < levelDataArray.Length; i++)
        {
            levelDataArray[i] = SaveSystem.LoadLevel(i + 1);
        }
    }

    private void ImportGameData()
    {

    }

    private void CalculateStars()
    {

    }

    public int GetTotalStars()
    {
        return totalAmountOfStars;
    }

    public int GetLatestUnlockedLevel()
    {
        return latestUnlockedLevel;
    }


}
