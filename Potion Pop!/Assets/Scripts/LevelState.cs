using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//levels faktiskt tilltåld
public class LevelState : MonoBehaviour
{
    //kan heta som objekten senare
    //kanske hashmap av ingredienser och goalAmount?
    public LevelData levelData;
    private int levelSavedAnimalsAmount;
    // mål för att få stjärnor
    [Header("2 stars = 1.5x, 3 stars = 2x")]
    [SerializeField] private int animalSavedOneStar;
    [SerializeField] private int animalSavedTwoStar;
    [SerializeField] private int animalSavedThreeStar;
    [SerializeField] private int starsUnlocked;

    [SerializeField] private float levelTimeLimit;
    
    [SerializeField] private Text animalsText;
    [Header("0 f?r att ej ha goal. S?TT TILL 3")]
    [Header("Samma ordning som array av ingredientsToCollect.")]
    [SerializeField] private int[] recipeIngredientGoals;
    [SerializeField] private GameObject[] ingredientsToSpawn;
    [SerializeField] private GameObject[] ingredientsToCollect;
    [SerializeField] private GameObject[] recipeIngredients;
    [SerializeField] private GameObject[] badIngrdients;
    [SerializeField] private GameObject[] powerups;
    

    private void Update()
    {
        
        animalsText.text = levelSavedAnimalsAmount.ToString();

    }

    public int GetSavedAnimals() {
        return levelSavedAnimalsAmount;
    }

    //ska få ingredients to Spawn 

    /*
     * Cauldron ska kommunicera med:
     * - AddIngredient(string name)
     * vad det är för ingrediens, via namn
     * om den finns i receptet (loop ingredientsToCollect)
     * om dens depå är fylld eller inte
     * counter för ingrediens ++, och UI 
     * */
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
