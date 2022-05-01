using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime = 1f;


    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadMainMenu()
    {
        StartCoroutine(LoadLevel(1));
    }

    public void LoadOptionsMenu()
    {
        StartCoroutine(LoadLevel(2));
    }

    public void LoadLevelSelect()
    {
        StartCoroutine(LoadLevel(3));
    }
    public void LoadSpecificLevel(int i)
    {
        StartCoroutine(LoadLevel(i));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
         
    }
}
