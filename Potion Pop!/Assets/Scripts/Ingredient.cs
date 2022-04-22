using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public string ingredientName;
    public int timesCollected;

    private void Start() {
        timesCollected = 0;
    }

    public void IncreaseTimesCollected() {
        timesCollected++;
    }
    
}
