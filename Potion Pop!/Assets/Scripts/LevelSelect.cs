using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
   // public GameState gameState; 
    public bool isOpen;
    [SerializeField] GameState gameState;
    [SerializeField] Image locker;
    [SerializeField] Sprite starAwake;
    [SerializeField] Sprite starSleep;
    [SerializeField] Image[] stars;
    public Button levelButton;


    
    [SerializeField] GameObject PopUpPlay;
    public TextMeshProUGUI uiLevelText;
    public TextMeshProUGUI uiButtonText;
    public TextMeshProUGUI uiScoreText;

    [SerializeField] Text time;
    [SerializeField] Text goal;
   
    [SerializeField] Button play;
   
    [SerializeField] Image[] popUpStars;
    [SerializeField] Image[] boxIngredients;  
 
    [SerializeField] string setGameTime;
    [SerializeField] int setGoal; 
    [SerializeField] int setLevelNumber;
    [SerializeField] Sprite[] setIngredients;
    [SerializeField] int score;



 
   
    private bool levelCompleted;
    private int scoreLimit = 20;
    private bool isOn;
    private static int levelIndex;
    private int unlockedStars;






    public void Start()
    {
        
        
        if (gameState.IsLevelUnlocked(setLevelNumber))
        {
            isOpen = true;
        }
        UpdateLevelImage();
        unlockedStars = gameState.GetLevelStars(setLevelNumber);
        setStarsAktive(popUpStars);
        setStarsAktive(stars);
    }

    public void updatePopUp()
    {
        
        setPopUpValues();
        SetIngredients();
        setStarsAktive(popUpStars);
        setStarsAktive(stars);
       
    }

    void SetIngredients()
    {
        for (int i = 0; i < boxIngredients.Length; i++)
        {
            boxIngredients[i].GetComponentInChildren<Image>().sprite = setIngredients[i];
        }
    }


    public void setStarsAktive(Image[] imageArray)
    {
       // int starsEarned = gameState.GetLevelStars(setLevelNumber);


        for (int i = 0; i < imageArray.Length; i++)
        {
           imageArray[i].gameObject.SetActive(isOpen);
           imageArray[i].GetComponent<Image>().sprite = starSleep;

            if (unlockedStars != 0)
            {
                for (int n = 0; n < unlockedStars; n++)
                {
                    imageArray[i].GetComponent<Image>().sprite = starAwake;
                }
            }
         
        }

    }

    private void setPopUpValues()
    {
      
        
        uiScoreText.SetText(score.ToString());
        uiLevelText.SetText( "Level "+ setLevelNumber.ToString());
        time.text = setGameTime;
        if (score >= scoreLimit)
        {
            setScoreBoard();          
        }
        else
        {
            goal.text = "x" + setGoal.ToString();
            uiButtonText.SetText("PLAY");
            
        }
    }

    private void setScoreBoard()
    {
        uiScoreText.SetText(score.ToString()+"000");
        uiButtonText.SetText("replay");
        levelCompleted = true;
    }

    public int getLevelNumber()
    {
        return levelIndex; 
    }

    public void UpdateLevelImage()
    {
        
        if (isOpen)
        {
            LevelOpen();          
        }
        else
        {
            
            LevelLocked();
        }

     }

    private void LevelLocked()
    {
        locker.gameObject.SetActive(!isOpen);
        setStarsAktive(stars);

    }



    public void LevelOpen()
    {
        LevelLocked();
        updatePopUp();
        levelIndex = setLevelNumber; 
        PopUpPlay.gameObject.SetActive(isOn);

        isOn = !isOn;

    }



    public void loadLevel()
    {
        //Debug.Log("Load levelnummer = " + setLevelNumber);
        
        SceneManager.LoadScene(levelIndex);
    }






}
