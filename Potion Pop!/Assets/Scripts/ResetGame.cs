using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    private bool popActive = true;
    [SerializeField] private GameState gameState;
    [SerializeField] private LevelLoader levelLoader;

    public GameObject resetButton;

    void Start()
    {
        resetButton.gameObject.SetActive(false);
    }

    public void PopUpState()
    {
       
        resetButton.gameObject.SetActive(popActive);
        popActive = !popActive;

    }

    public void ResetProgress()
    {
        //resetValues()
        levelLoader.LoadMainMenu();

    }

   


}
