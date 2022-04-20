using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//en för varje level
[System.Serializable]
public class LevelData : MonoBehaviour
{
    public float levelTimeLimit;
    public int oneStarGoal;
    public int twoStarGoal;
    public int threeStarGoal;

    public GameObject typeOneIngredient;
    public GameObject typeTwoIngredient;
    public GameObject typeThreeIngredient;
    public int ingredientOneGoal;
    public int ingredientTwoGoal;
    public int ingredientThreeGoal;

    //mängd,
    //ingredienstyper,
    //mängdkrävd per ingrediens,
    //antal räddade djur som krävs per stjärna,
    //tidsgräns

    public float getTimer()
    {
        return levelTimeLimit;
    }
}
