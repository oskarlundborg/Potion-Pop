using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelect : MonoBehaviour
{
    
    public bool isOpen;
    [SerializeField] Image locker;
    [SerializeField] Sprite starAwake;
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







    public void Start()
    {

        UpdateLevelImage();

        // kör loadData
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

        for (int i = 0; i < imageArray.Length; i++)
        {
            imageArray[i].gameObject.SetActive(isOpen);
            if (score >= scoreLimit + (i * scoreLimit))
            {
                imageArray[i].GetComponent<Image>().sprite = starAwake;
                
            }
             
          
        }

    }

    private void setPopUpValues()
    {

        uiScoreText.SetText(score.ToString());
        uiLevelText.SetText( "Level ");
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
        
        PopUpPlay.gameObject.SetActive(isOn);

        isOn = !isOn;

    }










}
