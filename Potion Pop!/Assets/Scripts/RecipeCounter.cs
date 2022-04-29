using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeCounter : MonoBehaviour
{
    private bool isFull;
    [SerializeField] private GameObject ingredient;
    [SerializeField] private int ingredientGoal;
    [SerializeField] private Text valueText;
    [SerializeField] private Image image;

    private int currentIngredientAmount;

    private void Start()
    {
        SetUpCounter();
    }

    public void AddIngredient() {
        if (currentIngredientAmount < ingredientGoal) {
            currentIngredientAmount++;
            UpdateProgress();
        }
        if (currentIngredientAmount == ingredientGoal) {
            isFull = true;
        }
    }

    public void SetUpCounter() {
        valueText = gameObject.GetComponentInChildren<Text>();
        image = gameObject.GetComponentInChildren<Image>();
        valueText.text = "0/" + ingredientGoal;
        
    }

    public void SubtractIngredient() {
        if (currentIngredientAmount > 0) {
            currentIngredientAmount--;
        }
        UpdateProgress();
    }

    public string GetIngredientName() {
        return ingredient.GetComponent<Ingredient>().GetIngredientName();
    }

    public void ResetCounter() {
        
        currentIngredientAmount = 0;
        UpdateProgress();
        isFull = false;
    }

    public bool IsFull() {
        return isFull;
    }

    public void UpdateProgress()
    {
        valueText.text = currentIngredientAmount + "/" + ingredientGoal;
    }
}


