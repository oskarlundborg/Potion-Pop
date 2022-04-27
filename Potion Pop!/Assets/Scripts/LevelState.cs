using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//levels faktiskt tilltåld
public class LevelState : MonoBehaviour
{
    private int savedAnimalsAmount;
    // mål för att få stjärnor
    [Header("2 stars = 1.5x, 3 stars = 2x")]
    [SerializeField] private int oneStarGoal;
    [SerializeField] private int twoStarGoal;
    [SerializeField] private int threeStarGoal;
    [SerializeField] private GameObject countdownBar;

    private GameObject cauldron;
    private bool isOneStarReached;
    private bool isTwoStarReached;
    private bool isThreeStarReached;
    private int starsUnlocked;
    private float maxTime;
    private float timeLeft;
    private bool isLevelStarted;
    [SerializeField] private int levelNumber;

    [SerializeField] private int basePickUpScore;
    private int pickUpScore;
    private int levelScore;
    private int highScore;

    [SerializeField] private float levelTimeLimit;
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
        //cauldron = GameObject.Find("Cauldron");
        SetUpTimer();
        pickUpScore = basePickUpScore;
    }

    public void StartGame()
    {
        isLevelStarted = true;
        startLevelButton.SetActive(false);
        //cauldron.GetComponent<Cauldron_Movement>().EnableCauldron();
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

    public bool GetLevelStarted() {
        return isLevelStarted;
    }

    public int GetSavedAnimals() {
        return savedAnimalsAmount;
    }

    public void AddIngredient(string name) {
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
            foreach (GameObject recipeCounter in recipeCounters)
            {
                recipeCounter.GetComponent<RecipeCounter>().SubtractIngredient();
            }
        }
    }

    private bool IsRecipeComplete() {
        bool isComplete = true;
        foreach (GameObject recipeCounter in recipeCounters) {
            if (recipeCounter.GetComponent<RecipeCounter>().IsFull() == false) {
                isComplete = false;
            }
        }
        return isComplete;
    }

    private void UpdateStarsStatus() {
        if (savedAnimalsAmount == threeStarGoal) {
            isThreeStarReached = true;
            starsUnlocked = 3;
        } else if (savedAnimalsAmount == twoStarGoal) {
            isTwoStarReached = true;
            starsUnlocked = 2;
        } else if (savedAnimalsAmount == oneStarGoal) {
            isOneStarReached = true;
            starsUnlocked = 1;
        }
    }

    private void RecipeCompleted()
    {
        savedAnimalsAmount++;
        UpdateStarsStatus();
        animalSavedText.text = "Animals saved: " + savedAnimalsAmount.ToString();
        foreach (GameObject recipeCounter in recipeCounters) {
            recipeCounter.GetComponent<RecipeCounter>().ResetCounter();
        }
    }

    private void UpdateTimer() {
        if (isLevelStarted) {
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

    private void LevelComplete() {
        isLevelStarted = false;
        cauldron.GetComponent<Cauldron_Movement>().DisableCauldron();
        foreach (GameObject recipeCounter in recipeCounters) {
            recipeCounter.SetActive(false);
        }
        levelCompletePanel.SetActive(true);
        //resten ska skötas av level complete panel 
        levelCompletePanel.GetComponent<LevelComplete>().ShowLevelProgression(starsUnlocked);
    }

    private void UpdateScore() {
        levelScore += pickUpScore;
        pickUpScore = pickUpScore * 2;
        if (levelScore > highScore) { //highscore ska vi spara, det högsta spelaren har fått på leveln
            highScore = levelScore;    // levelscore är de poängen som man fått under den aktiva spelrundan//när dessa är = så uppdaterar vi 
        }
    }

    public bool GetIsLevelStarted() {
        return isLevelStarted;
    }

    public void ResetCombo() {
        pickUpScore = basePickUpScore;
    }

    public int GetLevelHighScore() {
        return highScore;
    }

    public int GetLevelScore() {
        return levelScore;
    }

    public int GetStarsUnlocked() {
        return starsUnlocked;
    }

    public int GetLevelNumber() {
        return levelNumber;
    }

    
    /*
     * Levelstate skickar highScore och antal stjärnor till leveldata, och inten för levelnumber
     */
    
}

/*
 * HighScore
 * 
 * Varje gång man fångar en av recept - ingredienserna får man 5 poäng
 * 
 * När man fångat 5 av de ingredienserna som finns i receptet på raken, får man 10 poäng nästa gång man fångar en ingrediens 
 * 
 * 
 * SÄGA TILL LINUS:
 * reset score ska kallas på i cauldron när man fångar en debuff eller powerup
 */