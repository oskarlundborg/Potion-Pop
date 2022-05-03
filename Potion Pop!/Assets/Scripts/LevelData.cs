using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// FÖR SAVE-Files
// stjärnor per level

[System.Serializable]
public class LevelData 
{
    public int starsUnlocked;
    public int highScore;

    public LevelData(LevelState levelState) {
        highScore = levelState.GetLevelHighScore();
        starsUnlocked = levelState.GetStarsUnlocked();
    }
}

/*
 * Vi ska spara:
 * - highscore för varje level
 * - antal vunna stjärnor för varje level
 * - am i the latest played level
 * 
 * Ett annat script som har:
 * - totala vunna stjärnor för alla spelade levels 
 * - senast spelade level
 * 
 */


