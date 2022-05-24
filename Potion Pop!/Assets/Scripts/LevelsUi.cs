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

  
  
    private bool isPlaying;
    //private LevelSelect levelSelect;

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

    private void ButtonHandler(bool toggle)
    {
        for(int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].gameObject.SetActive(toggle);
        }
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

