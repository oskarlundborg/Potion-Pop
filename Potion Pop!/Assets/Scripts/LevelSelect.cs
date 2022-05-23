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

    private LevelLoader levelLoader;


    private int score; 
    private int unlockedStars;






    public void Start()
    {
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
        levelButton.interactable = false;
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
            score = gameState.GetLevelHighScore(setLevelNumber);
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
       
        
    }


    private void setPopUpValues()
    {
      
        
        uiScoreText.SetText(score.ToString());
        uiLevelText.SetText( "Level "+ setLevelNumber.ToString());
        uiButtonText.SetText("PLAY");
        time.text = setGameTime;
        goal.text = "x" + setGoal.ToString();
        
            
        
    }


    public int getLevelNumber()
    {
        return setLevelNumber; 
    }

    public void UpdateLevelImage()
    {
        locker.gameObject.SetActive(!isOpen);
        setStarsAktive(stars);
        setStarsAktive(popUpStars);

        if (isOpen)
        {
            updatePopUp();
            PopUpPlay.gameObject.SetActive(true);
      
        }

        LevelLocked();


    }

    public void LevelLocked()
    {
        locker.gameObject.SetActive(false);
        setStarsAktive(stars);
        setStarsAktive(popUpStars);
    }



    //public void LevelOpen()
    //{
    //    LevelLocked();
    //    updatePopUp();




    //    PopUpPlay.gameObject.SetActive(isOpen);

    //    isOn = !isOn;

    //}



    public void loadLevel()
    {

        levelLoader.LoadSpecificLevel(setLevelNumber);
    }

}
