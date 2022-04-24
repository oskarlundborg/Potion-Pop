using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonState : MonoBehaviour
{
    bool isAwake;
    public Button button;
    public Image ImageButton;
    public Sprite off;
    public Sprite on;



    public void changeText()
    {
        
        Text txt = transform.Find("Text").GetComponent<Text>();        
        txt.text = isAwake ? "ON" : "OFF";
        button.image.sprite = isAwake ? on : off;
        isAwake = !isAwake;

    }

}
