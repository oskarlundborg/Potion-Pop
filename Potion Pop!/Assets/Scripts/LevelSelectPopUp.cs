using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectPopUp : MonoBehaviour
{

    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject star1Active;
    [SerializeField] private GameObject star2Active;
    [SerializeField] private GameObject star3Active;
    [SerializeField] private GameObject star1Inactive;
    [SerializeField] private GameObject star2Inactive;
    [SerializeField] private GameObject star3Inactive;

    [SerializeField] private GameObject animalToSaveImage;
    [SerializeField] private Text animalsToSaveText;
    private int lastHighScore;
    private int animalsToSaveAmount;

    public void SetPopUpActive() {
        
        
    }
   
    //scriptet för varje pop-up för varje level, när spelaren

    // play-knapp
    // stjärnorna
    //ingredienser
    //hur många djur som ska räddas
    // tid
    // highscore

    /*
     * I Level Select pop-upen ska det synas om spelaren har spelat leveln förut eller inte. 
     * Om spelaren inte har spelat leveln förut ska det synas vilka ingredienser som spelaren ska fånga i leveln, och hur många djur som ska räddas och 
     * vilken djursort som ska räddas.
     * Om spelaren har spelat leveln förut ska high score för leveln synas, hur många stjärnor som spelaren har låst upp, djuren som ska räddas och antal djur
     * och vilka ingredienser som spelaren har samlat. 


    GameObjektet ska ha detta script på sig, och ha children:
    - PlayButton
    - Back to Level selection Button
    - Star1, Star2, Star3, med två lägen vardera (locked och unlocked)
    - Djur - image plus text som visar vilket djur och hur många av det djuret som ska räddas
    - Highscore nummer
    - Ingredienser som ska plockas - bild
     */
}
