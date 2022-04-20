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
    private Quest quest;
    private int levelSavedAnimalsAmount;
    private int starOneGoal;
    private int starTwoGoal;
    private int starThreeGoal;
    private float timer;
    [SerializeField] private Text animalsText;

    private void Start() {
        quest = new Quest(levelData);
    }

    private void Update()
    {
        levelSavedAnimalsAmount = quest.GetAnimalsSaved();
        animalsText.text = levelSavedAnimalsAmount.ToString();

    }

    /*public void SaveAnimals() {
       
    }
    */

    public int GetSavedAnimals() {
        return levelSavedAnimalsAmount;
    }

    public void CallOnAddOne() {
        quest.AddIngredientOne();
    }
    public void CallOnAddTwo()
    {
        quest.AddIngredientTwo();
    }
    public void CallOnAddThree()
    {
        quest.AddIngredientThree();
    }
}
