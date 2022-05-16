using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class LevelData 
{
    private bool isUnlocked;
    private int starsUnlocked;
    private int highScore;

    public LevelData(LevelState levelState) {
        highScore = levelState.GetLevelHighScore();
        starsUnlocked = levelState.GetStarsUnlocked();
    }
    public int GetStarsUnlocked() {
        return starsUnlocked;
    }
    public int GetHighScore() {
        return highScore;   
    }
    
    public bool GetIsUnlocked()
    {
        return isUnlocked;
    }

    public void UnlockLevel() 
    {
        isUnlocked = true;
    }

    public void LockLevel()
    {
        isUnlocked = false;
    }

}

