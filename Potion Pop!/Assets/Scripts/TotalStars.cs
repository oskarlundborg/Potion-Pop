using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class TotalStars : MonoBehaviour
{
    //GameState gameState;
    [SerializeField] TextMeshProUGUI numberStars;
   
    [SerializeField] private GameState gameState;

    private int totalStars;

    void Start()
    {
        StartCoroutine(setStars());
           
    }

  
    IEnumerator  setStars()
    {
        yield return new WaitForSeconds(0.1f);
        totalStars = gameState.GetTotalStars();
        Debug.Log(totalStars);
        Debug.Log(gameState.GetLevelHighScore(1));
        numberStars.SetText(totalStars.ToString());
    }

    

}
