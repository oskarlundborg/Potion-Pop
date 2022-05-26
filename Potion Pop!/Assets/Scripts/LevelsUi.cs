using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



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
    
    private static bool isMusicPlaying = true;
    private static bool isSoundPlaying = true;
    private static bool vibrate = true;
    private AudioSource audioSource;

   
    //private bool isPlaying;
    
    private GameObject openPopUp;



    void Start()
    {
        
        menuPopup.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();


    }


    public void OpenPopup(GameObject popUp)
    {
        menuPopup.gameObject.SetActive(false);
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
        MakeVibration(changeScene);
        
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
        MakeVibration(openPop);
        vibrate = !vibrate;     
    }

    public void SetBackgroundMusic(int i)
    {     
        MakeVibration(openPop);
        if( i == 1)
        {
            isSoundPlaying = !isSoundPlaying;
        }
        if (i == 2)
        {
            isMusicPlaying = !isMusicPlaying;
        }
      

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
        if (vibrate)
        {
            Handheld.Vibrate();
        }

    }





}


