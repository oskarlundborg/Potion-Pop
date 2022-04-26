using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeCounter : MonoBehaviour
{
    private bool isFull;
    [SerializeField] private GameObject ingredient;
    [SerializeField] private int ingredientGoal;
    [SerializeField] private RecipeCounter_UI ui;
    private int currentIngredientAmount;

    public void AddIngredient() {
        if (currentIngredientAmount < ingredientGoal) {
            currentIngredientAmount++;
            ui.UpdateProgress(currentIngredientAmount);
        }
        if (currentIngredientAmount == ingredientGoal) {
            isFull = true;
        }
    }

    public void SubtractIngredient() {
        if (currentIngredientAmount > 0) {
            currentIngredientAmount--;
        }
        ui.UpdateProgress(currentIngredientAmount);
    }

    public string GetIngredientName() {
        return ingredient.name;
    }

    public void ResetCounter() {
        
        currentIngredientAmount = 0;
        ui.UpdateProgress(currentIngredientAmount);
        isFull = false;
    }

    public bool IsFull() {
        return isFull;
    }
}


