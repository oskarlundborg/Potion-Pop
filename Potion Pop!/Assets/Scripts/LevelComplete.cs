using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class LevelComplete : MonoBehaviour
{
    [SerializeField] private Text levelText;
    [SerializeField] private Button buttonToMainLevel;
    [SerializeField] private Button replayButton;
    [SerializeField] private GameObject star1On;
    [SerializeField] private GameObject star1Off;
    [SerializeField] private GameObject star2On;
    [SerializeField] private GameObject star2Off;
    [SerializeField] private GameObject star3On;
    [SerializeField] private GameObject star3Off;
    [SerializeField] private LevelState levelState;

    [SerializeField] private Image animal1;
    [SerializeField] private Image animal2;
    [SerializeField] private Image animal3;


    private void Start()
    {
        levelText = gameObject.GetComponentInChildren<Text>();
    }
    public void ShowLevelProgression(int starsCollected)
    {

        levelText.text = "Level " + levelState.GetLevelNumber().ToString();
        if (starsCollected == 0) 
        {
            star1Off.SetActive(true);
            star2Off.SetActive(true);
            star3Off.SetActive(true);
        }
        else if (starsCollected == 1)
        {
            star1On.SetActive(true);
            star2Off.SetActive(true);
            star3Off.SetActive(true);
        }
        else if (starsCollected == 2)
        {
            star1On.SetActive(true);
            star2On.SetActive(true);
            star3Off.SetActive(true);
        }
        else if (starsCollected == 3)
        {
            star1On.SetActive(true);
            star2On.SetActive(true);
            star3On.SetActive(true);
        }
    }
}
