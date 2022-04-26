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

    private bool isOneStarReached;
    private bool isTwoStarReached;
    private bool isThreeStarReached;
    private int starsUnlocked;
    private float maxTime;
    private float timeLeft;


    [SerializeField] private float levelTimeLimit;
    [SerializeField] private GameObject[] recipeCounters;
    [SerializeField] private GameObject[] recipeIngredients;
    public GameObject[] ingredientsToSpawn;
    public GameObject[] debuffs;
    public GameObject[] powerups;

    [SerializeField] Text animalSavedText;
    [SerializeField] Text starsCollectedText;
    [SerializeField] GameObject levelCompletePanel;


    private void Start()
    {
        maxTime = levelTimeLimit;
        timeLeft = maxTime;
    }

    private void Update()
    {
        UpdateTimer();
    }

    public int GetSavedAnimals() {
        return savedAnimalsAmount;
    }

    public void AddIngredient(string name) {
        bool isCorrectIngredient = false;
        foreach (GameObject recipeCounter in recipeCounters) {
            if (name.Equals(recipeCounter.GetComponent<RecipeCounter>().GetIngredientName()))
            {
                isCorrectIngredient = true;
                recipeCounter.GetComponent<RecipeCounter>().AddIngredient();
                if (IsRecipeComplete())
                {
                    RecipeCompleted();

                }
            }
        }
        if (isCorrectIngredient == false) {
            foreach (GameObject recipeCounter in recipeCounters) {
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
        //kolla powerupstate
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

    private void LevelComplete() {
        Time.timeScale = 0;
        foreach (GameObject recipeCounter in recipeCounters) {
            recipeCounter.SetActive(false);
        }
        levelCompletePanel.SetActive(true);
        levelCompletePanel.GetComponent<LevelComplete>().ShowLevelProgression(starsUnlocked);
        // Visar alla stjärnor + knapp till nästa level
        // spara stjärnor - inte här
    }
}

/*
 * int starsUnlocked
 * int savedAnimalREquiredOneStar, TwoStar, ThreeStar
 * Gameobject [] ingredients
 * GameObject [] recipeIngredients
 * Gameobject [] bad ingrdients 
 * Gameobject [] powerups
 * int [] recipeGoals
 * 
 * 
 * Varje level har ett recept.
 * Ett recept är mallen för den potion som spelaren måste göra för att rädda djur i en level
 * Receptet innehåller de ingredienser som spelaren ska fånga, och hur många av varje ingrediens spelaren ska fånga.
 * När spelaren fångar de ingredienser som den ska, registreras detta och ökar på den ingrediensens depå
 * När en ingrediensdepå är fylld kommer inte räknaren att påverkas om spelaren plockar upp den ingrediensen.
 * När alla depåer är påfyllda är ett recept klart, och spelaren har räddat ett djur.
 * För att få stjärnor måste spelaren rädda ett x antal djur. Varje level har ett antal-gjorda-recept - mål för varje stjärna
 * När ett recept är klart nollställs alla infgrediensdepåer,och spelaren har chansen att göra klart ett till recept och rädda ett till djur
 * När timern är slut räknas antalet räddade djur, och översätts till det antal stjärnor som spelaren har fått under spelomgången.
 * 
 * 
 * 
 * Alla levels har gemensamt att de har 
 * 1. ett antal ingredienser som faller ned
 * 2. ett unikt recept med "rätt " ingredienser
 * 3. ingrediensmål för varje ingrediens
 * 4. Ui för varje ingrediensdepå
 * 5. en tidsBegränsning
 * 6. Gränser för 1, 2, 3 stjärnor
 * 
 * 
 * Varje gång en ingrediens fångas ska räknaren för den ingrediensen gå uppåt, om inte receptmålet för ingrediensen redan är mött
 * När alla depåer är fyllda,ska ingrediensdepåerna nollställas och spelaren får börja samla ingredienserna igen
 * Varje gång alla ingrediensdepåer är uppfyllda har spelaren räddat ett djur. 
 * I samband med att alla depåer är fyllda ska det kollas om gränsen för en stjärna är nådd. Om ja, ska en sjärna registreras. 
 * Om inte nollställs alla depåer utan att en stjärna registreras
 * 
 * Timer tickar på från att spelaren rör vid cauldron, som då startar igång spelomgången. När timern har löpt ut avbryts spelomgången
 * 
 * När en spelomgång är klar, sammanställs antal vunna stjärnor. 
 * 
 * För varje ingrediens i listan av ingredienser i receptet, ska en depå finnas för varje ingrediens. Med varje fångad ingrediens fylls den på
 * På skärmen ska en depå för varje ingrediens finnas, som är en ikon för den ingrediens den samlar. För varje ingrediens fylls depån för den ingrediensen på.
 * Ikonen blir i takt med påfyllning ifärgad, medan den i tomt tillstånd är en utgrånad ikon.
 * När alla depåer är fyllda töms depåerna och är tomma, och utgråade tills en ingrediens av den sorten samlas upp. 
 * En nedåtrörande timer-slider ska finnas på toppen av skärmen. När ingen tid har gått är timer full, och blir i takt med tidens gång
 * tommare och tommare. 
 * 
 * Cauldron har en trigger som kollar efter ingredienser vid kollision. När en ingrediens som har taggen ingrediens kommer i kontakt med collidern, ska den 
 * kalla på AddIngredient-metoden i LevelState. 
 * AddIngredient - metoden kollar om 
 * 
 */
