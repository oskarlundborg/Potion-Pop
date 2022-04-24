using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpState : MonoBehaviour
{

    public int powerUpState = 0;
    private float timer;

    void Start()
    {
        powerUpState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    public void setIce() {
        powerUpState = 1;
    }

    public void setSlow() {
        powerUpState = 2;
    }

    public void setFast() {
        powerUpState = 3;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(powerUpState == 1) {

        } else if(powerUpState == 2) {

        } else if(powerUpState == 3) {
            collision.GetComponent<Ingredient>().newFallingSpeed = collision.GetComponent<Ingredient>().fallingSpeed + 3;
        }

    }

}
