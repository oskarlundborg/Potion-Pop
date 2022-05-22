using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton_SoundManager : MonoBehaviour

{

    private AudioClip[] buttonSounds;
    AudioSource audioSource;
    public Button settingsButton, pauseButton, playButton, levelsButton, creditsButton, optionsButton, backToMenuButton, actualLevelButton;


    [SerializeField] AudioClip settingsButtonClip;
    [SerializeField] AudioClip pauseButtonClip;
    [SerializeField] AudioClip playButtonClip;
    [SerializeField] AudioClip levelsButtonClip;
    [SerializeField] AudioClip creditsButtonClip;

    [SerializeField] AudioClip optionsButtonClip;
    [SerializeField] AudioClip backToMenuButtonClip;
    [SerializeField] AudioClip actualLevelButtonClip;


    void Start()
    {
        buttonSounds = new AudioClip[] { settingsButtonClip, pauseButtonClip, playButtonClip, levelsButtonClip, creditsButtonClip, optionsButtonClip, backToMenuButtonClip, actualLevelButtonClip }; 
        audioSource = GetComponent<AudioSource>();

        settingsButton.onClick.AddListener(SettingButtonSound);
        pauseButton.onClick.AddListener(PauseButtonSound);
        playButton.onClick.AddListener(PlayButtonSound);
        levelsButton.onClick.AddListener(LevelsButtonSound);
        creditsButton.onClick.AddListener(CreditsButtonSound);

        optionsButton.onClick.AddListener(OptionsButtonSound);
        backToMenuButton.onClick.AddListener(BackToMenuButtonSound);
        actualLevelButton.onClick.AddListener(ActualLevelButtonButtonSound);


    }

    /* void soundsForUI()
     {
         AudioClip clip = buttonSounds[UnityEngine.Random.Range(0, buttonSounds.Length)];

         audioSource.PlayOneShot(clip);
     }
    */

    void SettingButtonSound()
    {
        
        audioSource.PlayOneShot(buttonSounds[0]);

    }

    void PauseButtonSound()
    {

        audioSource.PlayOneShot(buttonSounds[1]);

    }

    void PlayButtonSound()
    {

        audioSource.PlayOneShot(buttonSounds[2]);

    }

    void LevelsButtonSound()
    {

        audioSource.PlayOneShot(buttonSounds[3]);

    }
    void CreditsButtonSound()
    {

        audioSource.PlayOneShot(buttonSounds[4]);

    }
    void OptionsButtonSound()
    {

        audioSource.PlayOneShot(buttonSounds[5]);

    }

    void BackToMenuButtonSound()
    {

        audioSource.PlayOneShot(buttonSounds[6]);

    }

    void ActualLevelButtonButtonSound()
    {

        audioSource.PlayOneShot(buttonSounds[7]);

    }



}

