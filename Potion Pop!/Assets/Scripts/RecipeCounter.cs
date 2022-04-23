using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeCounter : MonoBehaviour
{
    public Text valueText;
    public Slider slider;
    private bool isFull;
    [SerializeField] private GameObject ingredient;
    [SerializeField] private int ingredientGoal;
    private int currentIngredientAmount;

    public void AddIngredient() {
        if (currentIngredientAmount < ingredientGoal) {
            currentIngredientAmount++;
            valueText.text = currentIngredientAmount.ToString();
            slider.value = currentIngredientAmount;
            Debug.Log("ingredient added" + currentIngredientAmount);
        }
        if (currentIngredientAmount == ingredientGoal) {
            isFull = true;
        }
    }

    public string GetIngredientName() {
        return ingredient.name;
    }

    public void ResetCounter() {
        currentIngredientAmount = 0;
    }

    public bool IsFull() {
        return isFull;
    }
}

/*
 * Säga till Linus;
 * ha en metod som returnerar Ingredient name i Ingredient, namnet bör vara private
 * Numera en counter för varje ingredient , och en array
 */
