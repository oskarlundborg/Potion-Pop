using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsUi : MonoBehaviour
{
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private GameObject menuPopup;
    [SerializeField] private GameObject LevelPopUp;
    [SerializeField] private AudioSource ambiance;

  
  
    private bool isPlaying;
   

  

 
    void Start()
    {
        
        menuPopup.gameObject.SetActive(false);
        LevelPopUp.gameObject.SetActive(false);
       

    }

    public void OpenPopup(GameObject popUp)
    {
        MakeVibration();
        popUp.gameObject.SetActive(true);
    }

    public void ClosePopup()
    {
        MakeVibration();
        menuPopup.gameObject.SetActive(false);
        LevelPopUp.gameObject.SetActive(false);

    }


    public void GoToMain()
    {
        MakeVibration();
        levelLoader.LoadMainMenu();
    }

    public void PlayLevel()
    {
        MakeVibration();

    }

    public void ButtonPressed()
    {
        MakeVibration();
    }

    public void SetBackgroundMusic()
    {
      
        if (isPlaying)
        {
            
            SetMusicOn();
        }
        else
        {
            SetMusicOff();
        }
        isPlaying = !isPlaying;
        
    }

    private void SetMusicOff()
    {
        ambiance.Stop();
        MakeVibration();
        //backgroundMusic.Stop();
    }

    private void SetMusicOn()
    {
        ambiance.Play();
        MakeVibration();
        
    }

    private void MakeVibration()
    {
        Handheld.Vibrate();
    }


}

