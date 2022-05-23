using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }

    IEnumerator FadeTrackCoroutine(int currentSong, int nextSong)
    {
        float timeToFade = 1.5f;
        float timeElapsed = 0f;
        Sound track02 = Array.Find(sounds, sounds => sounds.nr == nextSong);
        Sound track01 = Array.Find(sounds, sounds => sounds.nr == currentSong);
        if (track01!= null)
        {
            track02.source.Play();
            while (timeElapsed < timeToFade)
            {
                track02.source.volume = Mathf.Lerp(0, 1f, timeElapsed / timeToFade);
                track01.source.volume = Mathf.Lerp(1f, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            track01.source.Stop();
        }
        else { 
            track02.source.Play();
            while (timeElapsed < timeToFade)
            {
                track02.source.volume = Mathf.Lerp(0, 1f, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
        
        }
       

    }
    public void FadeTrack(int currentSong, int nextSong) {
        StartCoroutine(FadeTrackCoroutine(currentSong, nextSong));
    }

    // in objects FindObjectOfType<AudioManager>().Play("Music");
}
