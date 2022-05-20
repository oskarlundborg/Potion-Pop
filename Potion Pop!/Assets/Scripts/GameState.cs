using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private LevelData[] levelDataArray = new LevelData[9];
    private GameData gameData;
    private int totalAmountOfStars;
    private int lastUnlockedLevel;

    [Header("Stars needed to unlock level 1-9")]
    [SerializeField] private int[] levelStarGoals;



    void Start()
    {
        ImportLevelData();
        ImportGameData();
        UpdateStarAmount();
        SetLastUnlockedLevel();
    }

    private void ImportLevelData()
    {
        for (int i = 0; i < levelDataArray.Length; i++)
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
        foreach (LevelData levelData in levelDataArray)
        {
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
        for (int i = 0; i < levelDataArray.Length; i++)
        {
            if (levelDataArray[i].GetIsUnlocked())
            {
                continue;
            }
            lastUnlockedLevel = i;
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
        if (totalAmountOfStars >= levelStarGoals[levelNumber - 1])
        {
            return true;
        }
        return false;
    }

    public int GetLevelStars(int levelNumber)
    {
        if (levelDataArray[levelNumber - 1] != null)
        {
            return levelDataArray[levelNumber - 1].GetStarsUnlocked();
        }
        return 0;
    }
    public int GetLevelHighScore(int levelNumber)
    {
        if (levelDataArray[levelNumber - 1] != null)
        {
            return levelDataArray[levelNumber - 1].GetHighScore();
        }
        return 0;
    }

    public void SaveGame()
    {
        SaveSystem.SaveGameData(this);
    }
}
