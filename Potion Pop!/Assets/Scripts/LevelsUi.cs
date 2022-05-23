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
    //[SerializeField] private AudioSource backgroundMusic;
  
  
    private AudioSource audio;
    private bool isPlaying = true;
   
    //[SerializeField] private AudioClip exit;
    //[SerializeField] private AudioClip playLevel;
    //[SerializeField] private AudioClip goToMain;
    //[SerializeField] private AudioClip buttonPressed;
  

 
    void Start()
    {
        menuPopup.gameObject.SetActive(false);
        audio = gameObject.GetComponent<AudioSource>();
        SetBackgroundMusic();

    }

    public void OpenPopup()
    {
      
        menuPopup.gameObject.SetActive(true);
    }

    public void ClosePopup()
    {
        //SetAudio(exit);
        StartCoroutine(PopUpInactivate());
    }

     
    IEnumerator PopUpInactivate()
    {
        yield return new WaitForSeconds(0.1f);
        menuPopup.gameObject.SetActive(false);
        LevelPopUp.gameObject.SetActive(false);
    }

    public void GoToMain()
    {
        //SetAudio(goToMain);
        levelLoader.LoadMainMenu();
    }

    public void PlayLevel()
    {      
        //SetAudio(playLevel);
    
    }

    public void ButtonPressed()
    {
        //SetAudio(buttonPressed);
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
        //backgroundMusic.Stop();
    }

    private void SetMusicOn()
    {
        ambiance.Play();
        //backgroundMusic.Play();
    }

    private void SetAudio(AudioClip sound)
    {
        Handheld.Vibrate();
        audio.clip = sound;
        audio.Play();
    }
}

