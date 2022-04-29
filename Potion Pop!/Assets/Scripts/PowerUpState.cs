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
    private Cauldron_Movement cauldron;

    void Start()
    {
        magnet = GameObject.FindGameObjectWithTag("Magnet");
        cauldron = GameObject.Find("Cauldron").GetComponent<Cauldron_Movement>();
        powerUpState = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeLimit) {
            SetDefault();
        }
        if(powerUpState == 4) {
            magnet.SetActive(true);
        } else {
            magnet.SetActive(false);
        }
    }

    public void SetDefault() {
        powerUpState = 0;
        cauldron.setUnfrozen();
    }

    public void SetIce() {
        timer = 0f;
        powerUpState = 1;
        timeLimit = iceTimer;
        cauldron.setFrozen();
    }

    public void SetSlow() {
        timer = 0f;
        powerUpState = 2;
        timeLimit = slowTimer;
        cauldron.setUnfrozen();
    }

    public void SetFast() {
        timer = 0f;
        powerUpState = 3;
        timeLimit = fastTimer;
        cauldron.setUnfrozen();
    }

    public void SetMagnet() {
        timer = 0f;
        powerUpState = 4;
        timeLimit = magnetTimer;
        cauldron.setUnfrozen();
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
            ResetIngredientSpeed(collision);

        }

    }

    private void ResetIngredientSpeed(Collider2D collision) {
        collision.GetComponent<Ingredient>().newFallingSpeed = collision.GetComponent<Ingredient>().fallingSpeed;
        collision.GetComponent<Ingredient>().newRotateSpeed = collision.GetComponent<Ingredient>().rotateSpeed;
    }

}
