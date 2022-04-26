using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpState : MonoBehaviour
{

    public int powerUpState = 0;

    [SerializeField] private float iceTimer = 3f;
    [SerializeField] private float slowTimer = 6f;
    [SerializeField] private float fastTimer = 6f;
    [SerializeField] private float magnetTimer = 6f;

    private float timeLimit = 5f;

    private float timer;

    private GameObject magnet;

    void Start()
    {
        magnet = GameObject.FindGameObjectWithTag("Magnet");
        powerUpState = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeLimit) {
            powerUpState = 0;
        }
        if(powerUpState == 4) {
            magnet.SetActive(true);
        } else {
            magnet.SetActive(false);
        }
    }

    public void SetIce() {
        timer = 0f;
        powerUpState = 1;
        timeLimit = iceTimer;
    }

    public void SetSlow() {
        timer = 0f;
        powerUpState = 2;
        timeLimit = slowTimer;
    }

    public void SetFast() {
        timer = 0f;
        powerUpState = 3;
        timeLimit = fastTimer;
    }

    public void SetMagnet() {
        timer = 0f;
        powerUpState = 4;
        timeLimit = magnetTimer;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(powerUpState == 0) {
            ResetIngredientSpeed(collision);

        } else if (powerUpState == 1) { //Ice
            ResetIngredientSpeed(collision);

        } else if(powerUpState == 2) { //Slow
            collision.GetComponent<Ingredient>().newFallingSpeed = collision.GetComponent<Ingredient>().fallingSpeed / 2;
            collision.GetComponent<Ingredient>().newRotateSpeed = collision.GetComponent<Ingredient>().rotateSpeed / 2;

        } else if(powerUpState == 3) { //Fast
            collision.GetComponent<Ingredient>().newFallingSpeed = collision.GetComponent<Ingredient>().fallingSpeed + 3;
            collision.GetComponent<Ingredient>().newRotateSpeed = collision.GetComponent<Ingredient>().rotateSpeed * 2;

        } else if(powerUpState == 4) {
            
            
        }

    }

    private void ResetIngredientSpeed(Collider2D collision) {
        collision.GetComponent<Ingredient>().newFallingSpeed = collision.GetComponent<Ingredient>().fallingSpeed;
        collision.GetComponent<Ingredient>().newRotateSpeed = collision.GetComponent<Ingredient>().rotateSpeed;
    }

}
