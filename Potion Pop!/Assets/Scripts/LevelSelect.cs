using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] bool locked;
    [SerializeField] Image locker;
    [SerializeField] Sprite starAwake;
    [SerializeField] Image[] stars;
    
    

    [SerializeField] GameObject PopUpPlay;
    [SerializeField] Text levelTxt;
    [SerializeField] Text time;
    [SerializeField] Text goal;
    [SerializeField] Text goalText;
    [SerializeField] Button play;
    [SerializeField] Text buttonText;
    [SerializeField] Image[] popUpStars;
    [SerializeField] Image[] boxIngredients;  
 
    [SerializeField] string setGameTime;
    [SerializeField] int setGoal; 
    [SerializeField] int setLevelNumber;
    [SerializeField] Sprite[] setIngredients;
    [SerializeField] int score;

    private int starsUnlocked; // 0-3

    private int counter = 0;
   
    private bool levelCompleted;
    private int scoreLimit = 20;







    public void Start()
    {

        //updatePopUp();
        // kör loadData
    }

    public void updatePopUp()
    {
        setPopUpValues();
        UpdateLevelImage();
        SetIngredients();
        setStarsAktive(popUpStars);
        setStarsAktive(stars);
    }

    public void setStarsAktive(Image[] imageArray)
    {

        for (int i = 0; i < imageArray.Length; i++)
        {
            if (score >= scoreLimit + (i * scoreLimit))
            {
                imageArray[i].GetComponent<Image>().sprite = starAwake;
                levelCompleted = true;
            }
        }

    }

    private void setPopUpValues()
    {
        if (score >= scoreLimit)
        {
            setScoreBoard();
           
        }
        else
        {
            levelTxt.text = "Level " + setLevelNumber;
            time.text = setGameTime;
            goal.text = "x" + setGoal;
            buttonText.text = "PLAY";
        }
    }


    void SetIngredients()
    {
        for (int i = 0; i < boxIngredients.Length; i++)
        {
            boxIngredients[i].GetComponentInChildren<Image>().sprite = setIngredients[i];
        }
    }


    public void UpdateLevelImage()
    {

      

        LevelState(counter++);

     }

    public void LevelState(int i)
    {
        switch (i)
        {
            case 0:
                locker.gameObject.SetActive(true);
                break;
            case 1:
                LevelOpen();
                LevelPopUp(false);
                break;
            case 2:
                updatePopUp();
                LevelPopUp(true);
                counter = 1;
                break;
        }

    }

    private void LevelOpen()
    {
        locker.gameObject.SetActive(false);
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].gameObject.SetActive(true);
        }
    }

    private void LevelPopUp(bool toggle)
    {
        PopUpPlay.gameObject.SetActive(toggle);
        
    }

    private void setScoreBoard()
    {
        //       20       /     2 = 10
        int n = setGoal; // = 2
        int m = score / scoreLimit;
        goalText.text = (m + n) + "/" + n;
        goal.text = "";
        buttonText.text = "REPLAY";
        time.text = "SCORE";
        levelCompleted = true;
    }






}
