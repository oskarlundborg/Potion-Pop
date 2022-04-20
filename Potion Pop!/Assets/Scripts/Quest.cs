using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest 
{
    private bool isComplete;
    private GameObject ingredientTypeOne;
    private GameObject ingredientTypeTwo;
    private GameObject ingredientTypeThree;
    private int ingredientOneGoal;
    private int ingredientTwoGoal;
    private int ingredientThreeGoal;
    private int ingredientOneAmount;
    private int ingredientTwoAmount;
    private int ingredientThreeAmount;
    private int animalsSaved;
    private LevelData ld;

    private void ResetQuest()
    {
        if (isComplete) {
            ingredientOneAmount = 0;
            ingredientTwoAmount = 0;
            ingredientThreeAmount = 0;
            isComplete = false;
            Debug.Log("quest reset");
        }
    }

    public Quest(LevelData levelData)
    {
        this.ld = levelData;
        ingredientTypeOne = levelData.typeOneIngredient;
        ingredientTypeTwo = levelData.typeTwoIngredient;
        ingredientTypeThree = levelData.typeThreeIngredient;
        ingredientOneGoal = levelData.ingredientOneGoal;
        ingredientTwoGoal = levelData.ingredientTwoGoal;
        ingredientThreeGoal = levelData.ingredientThreeGoal;
    }

    //när en uingrediens hamnar i cauldron, kollar om den är ingredient som man vill ha
    //kallas på av Cauldron State när rätt ingrediens fångas
    public void AddIngredientOne()
    {
        if (ingredientOneAmount < ingredientOneGoal) {
            ingredientOneAmount++;
            Debug.Log("apple added");
            CheckGoals();
        }
    }

    public void AddIngredientTwo()
    {
        if (ingredientTwoAmount < ingredientTwoGoal) {
            ingredientTwoAmount++;
            Debug.Log("berry added");
            CheckGoals();
        }
    }  

    public void AddIngredientThree()
    {
        if (ingredientThreeAmount < ingredientThreeGoal) {
            ingredientThreeAmount++;
            Debug.Log("moss added");
            CheckGoals();
        }
    
    }

    public void CheckGoals()
    {
        if (ingredientOneAmount == ingredientOneGoal && ingredientTwoAmount == ingredientTwoGoal && ingredientThreeAmount == ingredientThreeGoal) {
            isComplete = true;
            animalsSaved++;
            Debug.Log("animals saved" + animalsSaved);
            ResetQuest();
  
        }
    }

    public int GetAnimalsSaved() {
        return animalsSaved;
    }

}


  