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
        StartCoroutine(UpdateStarAmount());
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
        Debug.Log(levelDataArray.Length);
      
        for(int i = 0; i < levelDataArray.Length; i++)
        {
            Debug.Log(levelDataArray[i].GetStarsUnlocked());
        }
        
    }

  

     IEnumerator UpdateStarAmount()
    {
        yield return new WaitForSeconds(0.1f);
        //totalAmountOfStars = GetStarsFromLevels();
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
            Debug.Log("true");
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



}
