using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class LevelData 
{
    private bool isLastLevel;
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
    
    public bool GetIsLastLevel()
    {
        return isLastLevel;
    }

    public void SetIsLastLevel() 
    {
        isLastLevel = !isLastLevel;
    }

}

