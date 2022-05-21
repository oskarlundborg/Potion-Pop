using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonState : MonoBehaviour
{
    bool isAwake;
    private Button button;
    
    public Sprite off;
    public Sprite on;


    

    public void changeText()
    {
        
        //Text txt = transform.Find("Text").GetComponent<Text>();        
        //txt.text = isAwake ? "ON" : "OFF";
        //button.image.sprite = isAwake ? on : off;
        //isAwake = !isAwake;

    }

    public void TurnOff(Button b)
           
    {
        if (b.image.sprite == off)
        {
            b.image.sprite = on;

        }
        else
        {
            b.image.sprite = off;
         
        }
    

    }



}
