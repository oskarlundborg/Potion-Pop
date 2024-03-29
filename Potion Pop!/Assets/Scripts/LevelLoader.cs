using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime = 1f;
    [SerializeField] private GameState gameState;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void LoadNextLevel()
    {
        if (gameState.IsLevelUnlocked(SceneManager.GetActiveScene().buildIndex + 1))
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    public void LoadMainMenu()
    {
        StartCoroutine(LoadLevel(10));
    }

    public void LoadOptionsMenu()
    {
        StartCoroutine(LoadLevel(11));
    }

    public void LoadLevelSelect()
    {
        StartCoroutine(LoadLevel(12));
    }

    public void LoadLatestUnlockedLevel()
    {
        StartCoroutine(LoadLevel(gameState.GetLastUnlockedLevel()));
    }

    public void LoadCredits()
    {
        StartCoroutine(LoadLevel(13));
    }
    public void LoadSpecificLevel(int i)
    {
        StartCoroutine(LoadLevel(i));
    }

    public void LoadSameLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        Time.timeScale = 1;

        transition.SetTrigger("Start");

        audioManager.FadeTrack(SceneManager.GetActiveScene().buildIndex, levelIndex);

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
