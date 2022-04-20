using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//en f�r varje level
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


    //m�ngd,
    //ingredienstyper,
    //m�ngdkr�vd per ingrediens,
    //antal r�ddade djur som kr�vs per stj�rna,
    //tidsgr�ns

    public float getTimer()
    {
        return levelTimeLimit;
    }
}
