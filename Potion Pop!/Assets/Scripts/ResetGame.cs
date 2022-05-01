using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    private bool popActive;

    public GameObject resetButton;

    void Start()
    {
        popUpState();
    }

    public void popUpState()
    {
        resetButton.gameObject.SetActive(popActive);
        popActive = !popActive;
    }


}
