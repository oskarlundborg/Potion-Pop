using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData
{
    private int lastUnlockedLevel;
    private int totalAmountOfStars;

    public GameData(GameState gameState) 
    {
        lastUnlockedLevel = gameState.GetLastUnlockedLevel();
        totalAmountOfStars = gameState.GetTotalStars();
    }
   
    public int GetLastLevelUnlocked() 
    {
        return lastUnlockedLevel;
    }
    public int GetTotalAmountOfStars() 
    {
        return totalAmountOfStars;
    }
}
