using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpState : MonoBehaviour
{

    public int powerUpState = 0;
    Animator animator;

    [SerializeField] private LevelState levelState;
    [SerializeField] private float iceDuration = 2f;
    [SerializeField] private float slowDuration = 4f;
    [SerializeField] private float fastDuration = 4f;
    [SerializeField] private float magnetDuration = 3f;

    private float duration = 5f;

    private float timer;

    private GameObject magnet;
    private Cauldron_Movement cauldron;

    void Start()
    {
        magnet = GameObject.FindGameObjectWithTag("Magnet");
        cauldron = GameObject.Find("Cauldron").GetComponent<Cauldron_Movement>();
        animator = cauldron.GetComponent<Animator>();
        powerUpState = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > duration) {
            SetDefault();
        }

        if(powerUpState == 1) {
            animator.SetBool("isIceState", true);
        } else {
            animator.SetBool("isIceState", false);
        }

    }

    public void SetDefault() {
        cauldron.SetDefault();
        powerUpState = 0;
    }

    public void SetIce() {
        timer = 0f;
        powerUpState = 1;
        duration = iceDuration;
    }

    public void SetSlow() {
        cauldron.SetDefault();
        timer = 0f;
        powerUpState = 2;
        duration = slowDuration;
        levelState.AddSeconds();
    }

    public void SetFast() {
        cauldron.SetDefault();
        timer = 0f;
        powerUpState = 3;
        duration = fastDuration;
    }

    public void SetMagnet() {
        cauldron.SetDefault();
        timer = 0f;
        powerUpState = 4;
        duration = magnetDuration;
        cauldron.SetMagnet();
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
            collision.GetComponent<Ingredient>().newFallingSpeed = collision.GetComponent<Ingredient>().fallingSpeed + 8;
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
