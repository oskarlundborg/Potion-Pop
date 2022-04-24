using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeCounter_UI : MonoBehaviour
{
    public Text valueText;
    public Slider slider;

    
    private void Start()
    {
        valueText = gameObject.GetComponentInChildren<Text>();
        slider = gameObject.GetComponentInChildren<Slider>();
    }

    public void UpdateProgress(int value)
    {
        valueText.text = value.ToString();
        slider.value = value;
    }

}
