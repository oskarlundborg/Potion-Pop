using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] Text starsCollectedText;
    [SerializeField] Button buttonToNextLevel;
    [SerializeField] GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;

    public void ShowLevelProgression(int starsCollected)
    {
        if (starsCollected == 1)
        {
            star1.SetActive(true);
            starsCollectedText.text = "Stars collected: " + starsCollected.ToString();
        }
        else if (starsCollected == 2)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            starsCollectedText.text = "Stars collected: " + starsCollected.ToString();
        }
        else if (starsCollected == 3)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
            starsCollectedText.text = "Stars collected: " + starsCollected.ToString();
        }
    }
}
