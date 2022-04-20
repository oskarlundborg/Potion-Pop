using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//en för varje level
[System.Serializable]
public class LevelData_Linus : MonoBehaviour
{
    public float levelTimeLimit;

    [Header("2 stars = 1.5x, 3 stars = 2x")]
    public int oneStarGoal;

    public GameObject[] ingredientsToSpawn;
    public GameObject[] ingredientsToCollect;
    
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
