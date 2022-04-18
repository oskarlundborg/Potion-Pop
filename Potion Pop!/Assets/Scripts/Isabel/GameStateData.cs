using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// är playerData

[System.Serializable]
public class GameStateData : MonoBehaviour
{
    private LevelData[] levelDataArray;
    [SerializeField] private int amountOfLevels = 3;

    public GameStateData(GameState gameState) {

        levelDataArray = new LevelData[amountOfLevels];
    }
}
