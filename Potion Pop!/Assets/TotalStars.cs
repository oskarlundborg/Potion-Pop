using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TotalStars : MonoBehaviour
{
    //GameState gameState;
    [SerializeField] TextMeshProUGUI numberStars;
    [SerializeField] int totalStars;

    void Start()
    {
        setStars();
    }

    private void setStars()
    {
        int stars;
        int s = totalStars;//gameState.GetTotalStars();
        if (s <= 0)
        {
            stars = 0;
        }
        else
        {
            stars = s;
        }
        numberStars.SetText(stars.ToString());
    }



}
