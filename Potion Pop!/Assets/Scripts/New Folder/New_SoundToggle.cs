using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class New_SoundToggle : MonoBehaviour
{

    private SoundToggle_MusicControl music;
    public Button musicToggleButton;
    public Sprite soundOn;
    public Sprite soundOff;

    void Start()
    {
        music = GameObject.FindObjectOfType<SoundToggle_MusicControl>();
        UpdateIcon();

    }

    void Update()
    {

    }

    public void PauseMusic()
    {
        music.ToggleSound();
        UpdateIcon();
    }

    void UpdateIcon()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            //AudioListener.volume = 1;
            AudioListener.pause = false;


            musicToggleButton.GetComponent<Image>().sprite = soundOn;

        }
        else
        {
            //AudioListener.volume = 0;
            AudioListener.pause = true;

            musicToggleButton.GetComponent<Image>().sprite = soundOff;
        }
    }

}
