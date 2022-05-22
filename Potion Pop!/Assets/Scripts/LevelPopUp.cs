using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class LevelPopUp : MonoBehaviour
{
    [SerializeField] GameObject popUp;
    public GameObject level;
    [SerializeField] Image[] starsSleep;
    [SerializeField] Sprite starAwake;
    [SerializeField] Image[] boxIngredients;
    

    private LevelSelect levelSelect;
    private LevelLoader levelLoader;



    private int score = 0;
    private int v1;
    //private string v2;
    //private string v3;
    private Sprite[] tempArray;


    void setIngredients(Sprite[] ingredients)
    {
        for (int i = 0; i < boxIngredients.Length; i++)
        {
            boxIngredients[i].GetComponentInChildren<Image>().sprite = ingredients[i];
        }
    }

    public void setScore(int i)
    {
        score = i;
    }

    public void setStarsAktive()
    {
        
        for(int i = 0; i < starsSleep.Length; i++)
        {
            if(score >= 20 + (i * 20)) {
                starsSleep[1].GetComponent<Image>().sprite = starAwake;
            }
        }
      
    }

  
   







    // Start is called before the first frame update
    void Start()
    {

    }
      

}
