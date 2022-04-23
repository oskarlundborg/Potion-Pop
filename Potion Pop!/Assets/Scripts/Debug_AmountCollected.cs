using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debug_AmountCollected : MonoBehaviour
{
    [Header("R?knas endast om r?tt ingrediens till receptet")]
    public Ingredient ingredientToDisplay;
    private Text amountCollectedText;

    void Start()
    {

        if(ingredientToDisplay == null) {
            gameObject.SetActive(false);
        }
        amountCollectedText = GetComponent<Text>();
    }

    void Update() {
        amountCollectedText.text = (ingredientToDisplay.GetIngredientName() + ":");
    }

}
