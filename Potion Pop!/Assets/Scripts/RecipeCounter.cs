using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeCounter : MonoBehaviour
{
    private bool isFull;
    [SerializeField] private GameObject ingredient;
    [SerializeField] private int ingredientGoal;
    [SerializeField] private Slider slider;
    private int currentIngredientAmount;

    public void AddIngredient() {
        if (currentIngredientAmount < ingredientGoal) {
            currentIngredientAmount++;
            //(valueText.text = currentIngredientAmount.ToString();
            slider.value = currentIngredientAmount;
            Debug.Log("ingredient added" + currentIngredientAmount);
        }
        if (currentIngredientAmount == ingredientGoal) {
            isFull = true;
        }
    }

    public void HandleWrongIngredient() {
        currentIngredientAmount--;
       // valueText.text = currentIngredientAmount.ToString();
        slider.value = currentIngredientAmount;
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


