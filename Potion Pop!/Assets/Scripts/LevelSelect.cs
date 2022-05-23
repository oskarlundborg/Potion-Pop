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


        StartCoroutine(UnlockLevel());
        unlockedStars = gameState.GetLevelStars(setLevelNumber);
        StartCoroutine(updatePopUp());
        
    }

    IEnumerator  updatePopUp()
    {
        yield return new WaitForSeconds(0.1f);

        setStarsAktive(stars);
        setStarsAktive(popUpStars);
        setPopUpValues();
        SetIngredients();
       

    }

    IEnumerator UnlockLevel()
    {
        yield return new WaitForSeconds(0.1f);
        if (gameState.IsLevelUnlocked(setLevelNumber))
        {
            isOpen = true;
            locker.gameObject.SetActive(!isOpen);
        }
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

        unlockedStars = gameState.GetLevelStars(setLevelNumber);
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
       
        
            //for (int n = 0; n < unlockedStars+1; n++)
            //{
            //    imageArray[n].GetComponent<Image>().sprite = starAwake;
            //}
        

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
        locker.gameObject.SetActive(!isOpen);
        setStarsAktive(stars);
        setStarsAktive(popUpStars);

        if (isOpen)
        {
            updatePopUp();
            levelIndex = setLevelNumber;
            PopUpPlay.gameObject.SetActive(true);

            //isOn = !isOn;
            //LevelOpen();          
        }
        //else
        //{
        //    LevelLocked();
        //}



    }

    public void LevelLocked()
    {
        locker.gameObject.SetActive(!isOpen);
        setStarsAktive(stars);
        setStarsAktive(popUpStars);
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
        
        SceneManager.LoadScene(levelIndex);
    }






}
