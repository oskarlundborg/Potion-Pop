using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeCounter : MonoBehaviour
{
    private bool isFull;
    private int currentIngredientAmount;
    [SerializeField] private Transform startPos;
    [SerializeField] private Transform endPos;
    [SerializeField] private float distanceLength;
    [SerializeField] private float distanceCovered;
    [SerializeField] private GameObject ingredient;
    [SerializeField] private int ingredientGoal;
    [SerializeField] private Text valueText;
    [SerializeField] private Image image;
    [SerializeField] private RawImage imageMask;

    private void Start()
    {
        SetUpCounter();
        distanceLength = Vector3.Distance(startPos.position, endPos.position);
        distanceCovered = distanceLength/currentIngredientAmount;
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
        imageMask = gameObject.GetComponentInChildren<RawImage>();
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
        distanceCovered = 0;
        isFull = false;
    }

    public bool IsFull() {
        return isFull;
    }

    public void UpdateProgress()
    {
        distanceCovered = distanceLength / ingredientGoal * currentIngredientAmount;
        valueText.text = currentIngredientAmount + "/" + ingredientGoal;
        float fractionOfDistance = distanceCovered / distanceLength;
        imageMask.transform.position = Vector3.Lerp(startPos.position, endPos.position, fractionOfDistance);
    }
}


