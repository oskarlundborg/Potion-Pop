using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{

    private bool popActive = true;
    [SerializeField] private GameState gameState;
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private AudioSource playSound;

    public GameObject resetButton;

    void Start()
    {
        resetButton.gameObject.SetActive(false);
    }

    public void PopUpState()
    {
        
        if (popActive)
        {
            playSound.Play();
        }
        resetButton.gameObject.SetActive(popActive);
        popActive = !popActive;

    }

    public void ResetProgress()
    {
        //resetValues()
        playSound.Play();
        levelLoader.LoadMainMenu();

    }

   


}
