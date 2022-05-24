using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class LevelsUi : MonoBehaviour
{
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private GameObject menuPopup;
    [SerializeField] private GameObject levelPopUp;
    [SerializeField] private AudioSource ambiance;
    [SerializeField] private Button [] levelButtons;
    [SerializeField] private AudioManager audioManager;


    private bool isPlaying;
    private bool vibrate = true;
  
    private GameObject openPopUp;

 
    void Start()
    {
        
        menuPopup.gameObject.SetActive(false);
     
    }

    public void OpenPopMenu()
    {
        menuPopup.gameObject.SetActive(true);
    }


    public void OpenPopup(GameObject popUp)
    {
        MakeVibration();
        ButtonHandler(false);
        if (openPopUp != null)
        {
            openPopUp.gameObject.SetActive(false);
        }
        popUp.gameObject.SetActive(true);
        openPopUp = popUp;
    }

    public void ClosePopup(GameObject popUp)
    {
        MakeVibration();
        menuPopup.gameObject.SetActive(false);
        popUp.gameObject.SetActive(false);
        ButtonHandler(true);
        
    }


    public void GoToMain()
    {
        MakeVibration();
        levelLoader.LoadMainMenu();
    }

    public void PlayLevel(int level)
    {
        MakeVibration();
        levelLoader.LoadSpecificLevel(level);
    }

    public void ButtonPressed()
    {
        MakeVibration();
    }

    public void SetVibrations()
    {
        MakeVibration();
        vibrate = !vibrate;
     
    }

    public void SetBackgroundMusic(int i)
    {
        MakeVibration();
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

    private void MakeVibration()
    {
        if (vibrate)
        {
            Handheld.Vibrate();
        }

    }




}


