using System.Collections;  
using UnityEngine;
using UnityEngine.UI;





public class LevelPopUp : MonoBehaviour
{
    [SerializeField] GameObject popUp;
    //[SerializeField] Image[] starsSleep;
    //[SerializeField] Sprite starAwake;
    //[SerializeField] Image[] boxIngredients;
    //private int levelen;
    //private LevelSelect levelSelect;







    //private int score = 0;



    //public void Ingredients(Sprite[] ingredients)
    //{
    //    for (int i = 0; i < boxIngredients.Length; i++)
    //    {
    //        boxIngredients[i].sprite = ingredients[i];
    //    }
    //}

    //public void setScore(int i)
    //{
    //    score = i;
    //}

    //public void setStarsAktive()
    //{
        
    //    for(int i = 0; i < starsSleep.Length; i++)
    //    {
    //        if(score >= 20 + (i * 20)) {
    //            starsSleep[1].GetComponent<Image>().sprite = starAwake;
    //        }
    //    }
      
    //}

  







    // Start is called before the first frame update
    void Start()
    {
        popUp.SetActive(false);
    }
      

}
