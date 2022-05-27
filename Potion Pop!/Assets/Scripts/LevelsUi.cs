using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class LevelsUi : MonoBehaviour
{
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private GameObject menuPopup;
    [SerializeField] private AudioSource ambiance;





    [SerializeField] private Button [] levelButtons;



    [SerializeField] private AudioClip Xbutton;
    [SerializeField] private AudioClip openPop;
    [SerializeField] private AudioClip playButton;
    [SerializeField] private AudioClip togglePress;
    [SerializeField] private AudioClip changeScene;
    [SerializeField] private AudioClip warning;
    [SerializeField] private AudioClip tempVibration;
    

   
    private AudioSource audioSource;
   
    
    private GameObject openPopUp;
    public static bool isVibrating = true;
    private static int previousLevel;



    void Start()
    {
        menuPopup.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();


    }


    public void OpenPopup(GameObject popUp)
    {
      
        MakeVibration(openPop);
        ButtonHandler(false);
        if (openPopUp != null)
        {
            openPopUp.gameObject.SetActive(false);
        }
        popUp.gameObject.SetActive(true);
        openPopUp = popUp;
    }

    public void openMenuPop()
    { 
   
        menuPopup.gameObject.SetActive(true);
        MakeVibration(openPop);
    }

    public void ClosePopup(GameObject popUp)
    {
       
        MakeVibration(Xbutton);
        menuPopup.gameObject.SetActive(false);
        popUp.gameObject.SetActive(false);
        ButtonHandler(true);
        
    }

    public void SwitchScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        previousLevel = scene.buildIndex;
        MakeVibration(changeScene);
        Debug.Log(previousLevel);
        
    }

    public void LoadPreviousLevel()
    {
        MakeVibration(changeScene);
        
        if (previousLevel != 0)
        {
            levelLoader.LoadSpecificLevel(previousLevel);
        }
        else
        {
            levelLoader.LoadMainMenu();
        }

        Debug.Log(previousLevel);
    }

    public void PlayLevel(int level)
    {   
        MakeVibration(playButton);
        levelLoader.LoadSpecificLevel(level);

    }

    public void PlayGame()
    {
        MakeVibration(playButton);

    }

    public void ButtonPressed()
    {  
        MakeVibration(openPop);
    }

    public void SetVibrations()
    {
        isVibrating = !isVibrating;      
        //Debug.Log("isVibrating = " +isVibrating);
        MakeVibration(openPop);
    }

    public void PlayAlert()
    {
        MakeVibration(warning);
        
    }

    public void ToggleSwitch()
    {
        MakeVibration(togglePress);
    }

    private void ButtonHandler(bool toggle)
    {
        if (levelButtons != null)
        {
            for (int i = 0; i < levelButtons.Length; i++)
            {
                levelButtons[i].gameObject.SetActive(toggle);
            }
        }
    }


    private void MakeVibration(AudioClip sfx)
    {    
        audioSource.clip = sfx;
        audioSource.Play();
        if (isVibrating)
        {
            Handheld.Vibrate();
        }

    }






}


