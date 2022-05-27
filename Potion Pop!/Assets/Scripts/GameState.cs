using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private LevelData[] levelDataArray = new LevelData[9];
    private GameData gameData;
    public int totalAmountOfStars; //Ska vara private i slutet
    private int lastUnlockedLevel;

    [Header("Stars needed to unlock level 1-9")]
    [SerializeField] private int[] levelStarGoals;

    

    void Start()
    {
        ImportLevelData();
        ImportGameData();
        SetLastUnlockedLevel();
        GetStarsFromLevels();
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

    private void GetStarsFromLevels()
    {      
        for(int i = 0; i < levelDataArray.Length; i++)
        {
            if(levelDataArray[i] != null)
            {
                totalAmountOfStars += levelDataArray[i].GetStarsUnlocked();
            }
        }
    }

    private void SetLastUnlockedLevel()
    {
        for (int i = 0; i < levelDataArray.Length; i++)
        {
            if (levelDataArray[i]!= null && levelDataArray[i].GetIsUnlocked())
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
        if (levelDataArray[levelNumber - 1] == null)
        {
            return 0;
          
        }
      
        return levelDataArray[levelNumber - 1].GetStarsUnlocked();
        
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

    public void ResetGame()
    {
        SaveSystem.ResetAll();
    }
}
