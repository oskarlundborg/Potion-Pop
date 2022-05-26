using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelState : MonoBehaviour
{
    private int savedAnimalsAmount;
    private int levelScore;
    private int highScore;
    private int starsUnlocked;
    private int combo = 1;
    private float maxTime;
    private float timeLeft;
    private bool isLevelStarted; //borde verkligen heta isPaused

    //Özge Stuff
    private int wholeSeconds;
    private bool timerStarted = false;
    public AudioSource audioSource;
    public AudioClip timeIsRunningOut;
    public float colorChangeSpeed;
    public Color lerpColor = Color.red;
    public GameObject particle;
    private Coroutine timeCoroutine = null; 


    [Header("2 stars = 1.5x, 3 stars = 2x")]
    [SerializeField] private int oneStarGoal;
    [SerializeField] private int twoStarGoal;
    [SerializeField] private int threeStarGoal;
    [SerializeField] private int levelNumber;
    [SerializeField] private int pickUpScore;
    [SerializeField] private float levelTimeLimit;

    [SerializeField] private GameObject countdownBar;
    [SerializeField] private GameObject[] recipeCounters;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject unpauseButton;
    [SerializeField] private GameObject quitToLevelSelectButton;
    [SerializeField] private GameObject playIcon;
    [SerializeField] private GameObject pauseIcon;
    [SerializeField] private AnimalQueue AnimalQueue;
    [SerializeField] private GameObject counterUI;
    [SerializeField] private float showPauseIconTime;


    public GameObject[] recipeIngredients;
    public GameObject[] ingredientsToSpawn;
    public GameObject[] debuffs;
    public GameObject[] powerups;

    //placeholder
    [SerializeField] Text animalSavedText;
    [SerializeField] Text starsCollectedText;
    [SerializeField] GameObject levelCompletePanel;
    [SerializeField] GameObject startLevelButton;

    private void Start()
    {
        LoadLevelState();
        SetUpTimer();
        
        //loopar igenom alla ps - (componentS för alla)
        foreach (ParticleSystem particleSystem in particle.GetComponentsInChildren<ParticleSystem>()) {
            particleSystem.Stop();
        }

    }

    public void StartGame()
    {
        isLevelStarted = true;
        startLevelButton.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void PauseGame() {

        if (isLevelStarted == true) 
        {
            Time.timeScale = 0;
            isLevelStarted = false;
            unpauseButton.SetActive(true);
            playIcon.SetActive(true);
            quitToLevelSelectButton.SetActive(true);
        }
    }

    public void UnpauseGame() {
        Time.timeScale = 1;
        unpauseButton.SetActive(false);
        quitToLevelSelectButton.SetActive(false);
        isLevelStarted = true;
        StartCoroutine(PauseCoroutine());
    }

    IEnumerator PauseCoroutine() {
        playIcon.SetActive(false);
        pauseIcon.SetActive(true);
        yield return new WaitForSeconds(showPauseIconTime);
        pauseIcon.SetActive(false);
    }

    public void SetUpTimer()
    {
        maxTime = levelTimeLimit;
        timeLeft = maxTime;
    }

    private void FixedUpdate()
    {
        UpdateTimer();
    }

    public bool GetLevelStarted()
    {
        return isLevelStarted;
    }

    public int GetSavedAnimals()
    {
        return savedAnimalsAmount;
    }

    public void AddIngredient(string name)
    {
        bool isCorrectIngredient = false;
        foreach (GameObject recipeCounter in recipeCounters)
        {
            if (name.Equals(recipeCounter.GetComponent<RecipeCounter>().GetIngredientName()))
            {
                isCorrectIngredient = true;
                UpdateScore();
                recipeCounter.GetComponent<RecipeCounter>().AddIngredient();
                if (IsRecipeComplete())
                {
                    RecipeCompleted();
                }
            }
        }
        if (isCorrectIngredient == false)
        {
            ResetCombo();
        }
    }

    public void AddSeconds()
    {
        timeLeft += 5f;

    }

    private bool IsRecipeComplete()
    {
        bool isRecipeComplete;
        foreach (GameObject recipeCounter in recipeCounters)
        {
            if (recipeCounter.GetComponent<RecipeCounter>().IsFull() == false)
            {
                return isRecipeComplete = false;
            }
        }
        return isRecipeComplete = true;
    }

    private void UpdateStarsStatus()
    {
        if (savedAnimalsAmount == threeStarGoal)
        {
            starsUnlocked = 3;
        }
        else if (savedAnimalsAmount == twoStarGoal)
        {
            starsUnlocked = 2;
        }
        else if (savedAnimalsAmount == oneStarGoal)
        {
            starsUnlocked = 1;
        }
    }

    private void UpdateScore()
    {
        levelScore += pickUpScore * combo;
        if (combo < 5)
        {
            combo++;
        }
        if (levelScore > highScore)
        {
            highScore = levelScore;
        }
    }

    private void UpdateTimer()
    {
        if (isLevelStarted)
        {
            if (timeLeft > 0)
            {
                //özge
                timeLeft -= Time.deltaTime;
                wholeSeconds =(int) timeLeft % 60;
                //
                countdownBar.GetComponent<Image>().fillAmount = timeLeft / maxTime;
                TimedSoundAndParticles();
            }
            else
            {
                LevelComplete();
            }
        }
    }
    
    //Özge
    private void TimedSoundAndParticles()
    {
        if (wholeSeconds == 10 && !timerStarted)
        {
            timeCoroutine = StartCoroutine(SoundEverySecond());
            timerStarted = true;
        }
        if (wholeSeconds <= 10)
        {
            lerpColor = Color.Lerp(Color.red, Color.blue, Mathf.PingPong(Time.time * colorChangeSpeed, 1));
            countdownBar.GetComponent<Image>().color = lerpColor;
            foreach (ParticleSystem particleSystem in particle.GetComponentsInChildren<ParticleSystem>())
            {
                particleSystem.Play();
            }

        }
        else if (wholeSeconds > 10 && timerStarted)
        {
            countdownBar.GetComponent<Image>().color = Color.white;
            StopCoroutine(timeCoroutine);
            timerStarted = false;
            foreach (ParticleSystem particleSystem in particle.GetComponentsInChildren<ParticleSystem>())
            {
                particleSystem.Stop();
            }
        }
    }

    //To Do, se till att när man tar buffs som förlänger tid ska lerp försvinna
    //Maybe use a bool och lägg in i update??

    //Özge
    private IEnumerator SoundEverySecond()
    {
        //infinite istället för for loopen innan med 10
        while (true) {
            yield return new WaitForSeconds(1);
            audioSource.PlayOneShot(timeIsRunningOut);
        }
    }

    private void RecipeCompleted()
    {
        savedAnimalsAmount++;
        UpdateStarsStatus();
        animalSavedText.text = "Animals saved: " + savedAnimalsAmount.ToString();
        foreach (GameObject recipeCounter in recipeCounters)
        {
            recipeCounter.GetComponent<RecipeCounter>().ResetCounter();
        }
        AnimalQueue.GetComponent<AnimalQueue>().TreatAnimals();
        if (savedAnimalsAmount >= threeStarGoal)
        {
            LevelComplete();
        }
    }

    private void LevelComplete()
    {
        isLevelStarted = false; 
        SaveLevelState();
        StartCoroutine(LevelCompleteCoroutine(4));
    }

    IEnumerator LevelCompleteCoroutine(float timeToWait)
    {
        //Özge
        if (timerStarted)
        {
            StopCoroutine(timeCoroutine);
        }

        foreach (ParticleSystem particleSystem in particle.GetComponentsInChildren<ParticleSystem>())
        {
            particleSystem.Stop();
        }
        //
        unpauseButton.SetActive(false);
        pauseButton.SetActive(false);
        foreach (GameObject recipeCounter in recipeCounters)
        {
            recipeCounter.SetActive(false);
        }
        yield return new WaitForSeconds(timeToWait);
        levelCompletePanel.SetActive(true);
        levelCompletePanel.GetComponent<LevelComplete>().ShowLevelProgression(starsUnlocked);
        counterUI.SetActive(false);
    }
    public bool GetIsLevelStarted()
    {
        return isLevelStarted;
    }

    public void ResetCombo()
    {
        combo = 1;
    }

    public int GetLevelHighScore()
    {
        return highScore;
    }

    public int GetLevelScore()
    {
        return levelScore;
    }

    public int GetStarsUnlocked()
    {
        return starsUnlocked;
    }

    public int GetLevelNumber()
    {
        return levelNumber;
    }

    public void LoadLevelState() {

        LevelData levelData = SaveSystem.LoadLevel(levelNumber);
        if (levelData != null) {
            highScore = levelData.GetHighScore();
            starsUnlocked = levelData.GetStarsUnlocked();
        } 
    }

    public void SaveLevelState() {
        SaveSystem.SaveLevel(this);
    }
}