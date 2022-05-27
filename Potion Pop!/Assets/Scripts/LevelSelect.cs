using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;


public class LevelSelect : MonoBehaviour
{
   
    public bool isOpen;

  
    [SerializeField] private GameState gameState;
    [SerializeField] private Image locker;
    [SerializeField] private Sprite starAwake;
    [SerializeField] private Sprite starSleep;
    [SerializeField] private Image[] stars;
    [SerializeField] private Button levelButton;


    
    [SerializeField] GameObject PopUp;

    [SerializeField] private TextMeshProUGUI uiScoreText;
    [SerializeField] private Text time;
    [SerializeField] private Text goal;
   
    [SerializeField] private Button play;
    [SerializeField] private Image[] popUpStars;
    [SerializeField] private Image[] boxIngredients;
    [SerializeField] private int level;
    [SerializeField] private string setGameTime;
    [SerializeField] private int setGoal; 
    
    
    public static int score; 
    private int unlockedStars;




    void Start()
    {
        levelButton.interactable = false;
        unlockedStars = gameState.GetLevelStars(level);
        score = gameState.GetLevelHighScore(level);
        StartCoroutine(UnlockLevel());
        StartCoroutine(UpdatePopUp());
        StartCoroutine(setPopUpValues());
        Debug.Log("hej start");
    }




    IEnumerator  UpdatePopUp()
    {
        yield return new WaitForSeconds(0.1f);
        unlockedStars = gameState.GetLevelStars(level);   
        setStarsAktive(stars);
        setStarsAktive(popUpStars);
        score = gameState.GetLevelHighScore(level);
        
    }

    IEnumerator UnlockLevel()
    {
        yield return new WaitForSeconds(0.1f);
        
        if (gameState.IsLevelUnlocked(level))
        {
            isOpen = true;
            locker.gameObject.SetActive(!isOpen);
            levelButton.interactable = true;

            
        }
     
    }

    IEnumerator setPopUpValues()
    {
        yield return new WaitForSeconds(0.5f);
        uiScoreText.SetText(score.ToString());
        time.text = setGameTime;
        goal.text = "x" + setGoal.ToString();

    }


    public void setStarsAktive(Image[] imageArray)
    {

        unlockedStars = gameState.GetLevelStars(level);
        for (int i = 0; i < imageArray.Length; i++)
        {
            imageArray[i].gameObject.SetActive(isOpen);
            if (i+1 <= unlockedStars)// 2
            {
    
                imageArray[i].GetComponent<Image>().sprite = starAwake;
                
            }
            else
            {
      
                imageArray[i].GetComponent<Image>().sprite = starSleep;
             
            }
        }
       
        
    }


    public void LevelLocked()
    {
        locker.gameObject.SetActive(false);
        setStarsAktive(stars);
        setStarsAktive(popUpStars);
    }

}
