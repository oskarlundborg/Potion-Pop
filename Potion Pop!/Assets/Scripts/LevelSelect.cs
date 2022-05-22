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

    private int score; 
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
        SetStarsAktive(stars);
        SetStarsAktive(popUpStars);
        SetPopUpValues();
        SetIngredients();     
        score = gameState.GetLevelHighScore(setLevelNumber);

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

    public void SetStarsAktive(Image[] imageArray)
    {
        unlockedStars = gameState.GetLevelStars(setLevelNumber);
        for (int i = 0; i < imageArray.Length; i++)
        {
            imageArray[i].gameObject.SetActive(isOpen);
            if (i+1 <= unlockedStars)
            {
                imageArray[i].GetComponent<Image>().sprite = starAwake;
            }
            else
            {
                imageArray[i].GetComponent<Image>().sprite = starSleep;
            }
        }
    }

    public void SetPopUpValues()
    {
        uiButtonText.SetText("play");
        uiLevelText.SetText("Level " + setLevelNumber.ToString());
        uiScoreText.SetText(score.ToString());
        goal.text = "x" + setGoal.ToString();   
        time.text = setGameTime;      
    }

    public int GetLevelNumber()
    {
        return setLevelNumber; 
    }

    public void UpdateLevelImage()
    {     
        locker.gameObject.SetActive(!isOpen);
        SetStarsAktive(stars);
        SetStarsAktive(popUpStars);
        if (isOpen)
        {
            StartCoroutine(updatePopUp());         
            PopUpPlay.gameObject.SetActive(true);
               
        }
    }

    public void loadLevel()
    {
        SceneManager.LoadScene(setLevelNumber);
    }






}
