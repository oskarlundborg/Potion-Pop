using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron_Movement : MonoBehaviour
{
    private float cauldronPosY;

    void Start() 
    { 
        cauldronPosY = transform.position.y; //Sparar Y-startposition
    }

    void Update() {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x, cauldronPosY); //Följer datormusens x-led
    }
}
