using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IkonState : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private   Sprite ikonOn;
    [SerializeField] private  Sprite ikonOff;

    private  bool ikonState = true;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void SetIkonState()
    {
        button.image.sprite = (button.image.sprite == ikonOff) ? ikonOn : ikonOff;
        ikonState = !ikonState;
    }

 

 
}
