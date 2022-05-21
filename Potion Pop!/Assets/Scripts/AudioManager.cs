using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    [SerializeField] private float delayFadeIn = 20f;
    [SerializeField] private float delayFadeOut = 1f;
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
    
    void Start() {
        /*
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Nobi")
        {
            Play("SkogsområdeLevel1");
        }
        else if (sceneName == "Nobi_ljud2.0") {
            Play("SkogsområdeLevel2");
        }
        */

    }
    // Update is called once per frame
    public void Play(int nr)
    {
        Sound s = Array.Find(sounds, sound => sound.nr == nr);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + nr + " not found.");
            return;
        }
        StartCoroutine(FadeIn());
        s.source.Play();
    }
  
    public IEnumerator FadeIn()
    {
        float elapsedTime = 0;
        float currentVolume = AudioListener.volume;

        while (elapsedTime < delayFadeIn)
        {
            elapsedTime += Time.deltaTime;
            AudioListener.volume = Mathf.Lerp(0, currentVolume, elapsedTime / delayFadeIn);
            yield return null;
        }
    }
    public IEnumerator FadeOut()
    {
        float elapsedTime = 0;
        float currentVolume = AudioListener.volume;

        while (elapsedTime < delayFadeIn)
        {
            elapsedTime += Time.deltaTime;
            AudioListener.volume = Mathf.Lerp(currentVolume, 0, elapsedTime / delayFadeOut);
            yield return null;
        }
    }

    // in objects FindObjectOfType<AudioManager>().Play("Music");
}
