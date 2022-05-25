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
    [SerializeField] private AudioClip pressPlayButton;
    [SerializeField] private AudioClip togglePress;
    [SerializeField] private AudioClip changeScene;
    [SerializeField] private AudioClip warning;

    private AudioSource audioSource;

   
    private bool isPlaying;
    private bool vibrate = true;  
    private GameObject openPopUp;

 
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

   


    public void GoToMain()
    {
      
        MakeVibration(changeScene);
        levelLoader.LoadMainMenu();
    }

    public void PlayLevel(int level)
    {
        
        MakeVibration(pressPlayButton);
        levelLoader.LoadSpecificLevel(level);
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
        if (isPlaying)
        {
            //SetMusicOn();
        }
        else
        {
            //setMusicOff(i);
            SetMusicOff(i);  
        }
        isPlaying = !isPlaying;

    }

    public void playAlert()
    {
        MakeVibration(warning);
    }

    public void toggleSwitch()
    {
        MakeVibration(togglePress);
    }

    private void ButtonHandler(bool toggle)
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].gameObject.SetActive(toggle);
        }
    }

    private void SetMusicOff(int i)
    {
        //ambiance.Stop();
    }


    private void SetMusicOn()
    {
        //ambiance.Play();
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


