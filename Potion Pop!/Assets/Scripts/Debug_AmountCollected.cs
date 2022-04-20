using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debug_AmountCollected : MonoBehaviour
{
    [Header("Räknas endast om rätt ingrediens till receptet")]
    public Ingredient ingredientToDisplay;
    private Text amountCollectedText;

    // Start is called before the first frame update
    void Start()
    {

        if(ingredientToDisplay == null) {
            gameObject.SetActive(false);
        }
        amountCollectedText = GetComponent<Text>();
    }

    void Update() {
        amountCollectedText.text = (ingredientToDisplay.ingredientName + ":" + ingredientToDisplay.timesCollected);
    }

}
