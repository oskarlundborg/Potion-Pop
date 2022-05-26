using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    
    [SerializeField] private GameState gameState;
    [SerializeField] private LevelLoader levelLoader;

    public GameObject resetButton;

    void Start()
    {
        resetButton.gameObject.SetActive(false); 
    }


    public void ResetProgress()
    {
        gameState.ResetGame();
        levelLoader.LoadMainMenu();

    }
}
