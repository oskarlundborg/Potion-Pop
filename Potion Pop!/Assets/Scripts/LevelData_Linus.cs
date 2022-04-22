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
    
    [Header("0 för att ej ha goal. Sätt array length till 3")]
    [Header("Samma ordning som array av ingredientsToCollect.")]
    public int[] ingredientGoal;

    public void CheckGoal() {
        bool goalOneReached = false, goalTwoReached = false, goalThreeReached = false;

        if (ingredientsToCollect[0].GetComponent<Ingredient>().timesCollected >= ingredientGoal[0] || ingredientGoal[0] == 0) {
            goalOneReached = true;
        }
        if (ingredientsToCollect[1].GetComponent<Ingredient>().timesCollected >= ingredientGoal[1] || ingredientGoal[1] == 0) {
            goalTwoReached = true;
        }
        if (ingredientsToCollect[2].GetComponent<Ingredient>().timesCollected >= ingredientGoal[2] || ingredientGoal[2] == 0) {
            goalThreeReached = true;
        }
        if(goalOneReached && goalTwoReached && goalThreeReached) { //Goal reached
            Debug.Log("Goal!!!");
        }
    }

    public float getTimer()
    {
        return levelTimeLimit;
    }
}
