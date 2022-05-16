using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private LevelData[] levelDataArray = new LevelData[9];
    private GameData gameData;
    private int totalAmountOfStars;
    private int lastUnlockedLevel;

    [Header("Stars needed to unlock level 2-9")]
    [SerializeField] private int[] levelStarGoals;
    


    void Start()
    {
        ImportLevelData();
        ImportGameData();
        UpdateStarAmount();
        UpdateLevelLocks();
        SetLastUnlockedLevel();
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
        gameData = SaveSystem.LoadGameData();
        if (gameData == null)
        {
            lastUnlockedLevel = 1;
            totalAmountOfStars = 0;
            return;
        }
        lastUnlockedLevel = gameData.GetLastLevelUnlocked();
        totalAmountOfStars = gameData.GetTotalAmountOfStars(); //redundant 
    }

    private int GetStarsFromLevels() 
    {
        int stars = 0;
        foreach (LevelData levelData in levelDataArray) {
            if (levelData != null) 
            {
                stars += levelData.GetStarsUnlocked();
            }
        }
        return stars;
    }

    private void UpdateStarAmount()
    {
        totalAmountOfStars = GetStarsFromLevels();
    } 

    private void SetLastUnlockedLevel()
    {
        for(int i = 0; i < levelDataArray.Length; i++)
        {
            if (levelDataArray[i].GetIsUnlocked())
            {
                continue;
            }
            lastUnlockedLevel = i;
        }
    }

    private void UpdateLevelLocks()
    {
        for(int i = 0; i < levelStarGoals.Length; i++)
        {
            if(totalAmountOfStars >= levelStarGoals[i])
            {
                levelDataArray[i + 1].UnlockLevel();
            }
        }
    }

    public int GetLastUnlockedLevel()
    {
        return lastUnlockedLevel;
    }
       
    public int GetTotalStars()
    {
        return totalAmountOfStars;
    }

    public bool IsLevelUnlocked(int levelNumber)
    {
        return levelDataArray[levelNumber - 1].GetIsUnlocked();
    }

    public int GetLevelStars(int levelNumber) 
    {
        return levelDataArray[levelNumber - 1].GetStarsUnlocked();
    }

    public int GetLevelHighScore(int levelNumber)
    {
        return levelDataArray[levelNumber - 1].GetHighScore();
    }
     
    public void SaveGame()
    {
        SaveSystem.SaveGameData(this);
    }
}
