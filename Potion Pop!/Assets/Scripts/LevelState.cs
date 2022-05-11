using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//levels faktiskt tilltåld
public class LevelState : MonoBehaviour
{
    private int savedAnimalsAmount;
    private int levelScore;
    private int highScore;
    private int starsUnlocked;
    private int combo = 1;
    private float maxTime;
    private float timeLeft;
    //ska bli private bool isLevelRunning;
    private bool isLevelStarted;

    // vilka djur som ska räddas och hur många!!!
    
    // mål för att få stjärnor
    [Header("2 stars = 1.5x, 3 stars = 2x")]
    [SerializeField] private int oneStarGoal;
    [SerializeField] private int twoStarGoal;
    [SerializeField] private int threeStarGoal;
    [SerializeField] private int levelNumber;
    [SerializeField] private int pickUpScore;
    [SerializeField] private float levelTimeLimit;

    [SerializeField] private GameObject countdownBar;
    [SerializeField] private GameObject[] recipeCounters;
    [SerializeField] private GameObject[] recipeIngredients;
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
    }

    public void StartGame()
    {
        isLevelStarted = true;
        startLevelButton.SetActive(false);
    }

    public void SetUpTimer()
    {
        maxTime = levelTimeLimit;
        timeLeft = maxTime;
    }

    private void Update()
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

    private bool IsRecipeComplete()
    {
        bool isComplete = true;
        foreach (GameObject recipeCounter in recipeCounters)
        {
            if (recipeCounter.GetComponent<RecipeCounter>().IsFull() == false)
            {
                isComplete = false;
            }
        }
        return isComplete;
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

    private void RecipeCompleted()
    {
        savedAnimalsAmount++;
        UpdateStarsStatus();
        animalSavedText.text = "Animals saved: " + savedAnimalsAmount.ToString();
        foreach (GameObject recipeCounter in recipeCounters)
        {
            recipeCounter.GetComponent<RecipeCounter>().ResetCounter();
        }
    }

    private void UpdateTimer()
    {
        if (isLevelStarted)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                countdownBar.GetComponent<Image>().fillAmount = timeLeft / maxTime;
            }
            else
            {
                LevelComplete();
            }
        }
    }

    private void LevelComplete()
    {
        isLevelStarted = false;
        SaveLevelState();
        foreach (GameObject recipeCounter in recipeCounters)
        {
            recipeCounter.SetActive(false);
        }
        levelCompletePanel.SetActive(true);
        levelCompletePanel.GetComponent<LevelComplete>().ShowLevelProgression(starsUnlocked);
    }

    private void UpdateScore()
    {
        levelScore += pickUpScore * combo;
        if (combo < 5) {
            combo++;
        }
        if (levelScore > highScore)
        { //highscore ska vi spara, det högsta spelaren har fått på leveln
            highScore = levelScore;    // levelscore är de poängen som man fått under den aktiva spelrundan//när dessa är = så uppdaterar vi 
        }
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
            highScore = levelData.highScore;
            starsUnlocked = levelData.starsUnlocked;
        } 
    }

    public void SaveLevelState() {
        SaveSystem.SaveLevel(this);
    }
}