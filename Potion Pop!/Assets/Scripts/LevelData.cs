using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// FÖR SAVE-Files
// stjärnor per level
// 
[System.Serializable]
public class LevelData : MonoBehaviour
{
    public float levelTimeLimit;
    public int oneStarGoal;
    public int twoStarGoal;
    public int threeStarGoal;

    public GameObject[] ingredientsToSpawn;

    public GameObject typeOneIngredient;
    public GameObject typeTwoIngredient;
    public GameObject typeThreeIngredient;
    public int ingredientOneGoal;
    public int ingredientTwoGoal;
    public int ingredientThreeGoal;

    public float getTimer()
    {
        return levelTimeLimit;
    }

}


