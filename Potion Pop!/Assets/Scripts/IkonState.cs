using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IkonState : MonoBehaviour
{
    [SerializeField] private  Button button;
    [SerializeField] private   Sprite ikonOn;
    [SerializeField] private  Sprite ikonOff;


    public void Start()
    {
        SetIkonState();
    }


    public void SetIkonState()
    {

        button.image.sprite = (LevelsUi.isVibrating) ? ikonOn : ikonOff;


        if (LevelsUi.isVibrating == false)
        {
           
            //Debug.Log("ikonOff =" + LevelsUi.isVibrating);
            
        }
        if(LevelsUi.isVibrating == true)
        {
          
            //Debug.Log("ikonOn =" + LevelsUi.isVibrating);
          
        }

      
    }

 
}
