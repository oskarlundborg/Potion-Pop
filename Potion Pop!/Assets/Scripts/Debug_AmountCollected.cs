using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debug_AmountCollected : MonoBehaviour
{

    private Text amountCollectedText;

    // Start is called before the first frame update
    void Start()
    {
        amountCollectedText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncreaseAmountCollected(int i) {

    }

}
