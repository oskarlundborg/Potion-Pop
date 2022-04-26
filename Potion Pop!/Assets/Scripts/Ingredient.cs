using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public string ingredientName;

    private Animator animator;

    [Header("Rotate")]
    public float minSpeed = 40f;
    public float maxSpeed = 150f;

    private bool rotatesClockwise;
    [HideInInspector] public float rotateSpeed;
    [HideInInspector] public float newRotateSpeed;

    [Header("Falling speed")]
    public float fallingSpeed = 2f;
    [HideInInspector] public float newFallingSpeed;
    private Rigidbody2D rb;

    private PowerUpState powerUpState;

    void Start() {
        powerUpState = GameObject.FindGameObjectWithTag("PowerUpState").GetComponent<PowerUpState>();

        animator = gameObject.GetComponent<Animator>();
        newFallingSpeed = fallingSpeed;

        //Väljer randomly hur snabbt objektet ska rotera
        rotateSpeed = Random.Range(minSpeed, maxSpeed);
        newRotateSpeed = rotateSpeed;

        //Väljer randomly vilket håll objektet ska rotera
        int temp = Random.Range(1, 10);
        if (temp % 2 == 0) {
            rotatesClockwise = false;
        } else {
            rotatesClockwise = true;
        }

        rb = GetComponent<Rigidbody2D>(); //For rotating

    }

    void Update() { 
        if (rotatesClockwise) { //Rotating
            transform.Rotate(Vector3.forward * Time.deltaTime * newRotateSpeed);
        } else {
            transform.Rotate(Vector3.forward * Time.deltaTime * (newRotateSpeed * -1));
        }

        //Keep ingredients in bounds
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0, 1 );
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void FixedUpdate() {
        if (powerUpState.powerUpState == 4) { //isMagnetState? 
            rb.velocity = new Vector3(rb.velocity.x, -newFallingSpeed, 0);
        } else {
            rb.velocity = new Vector3(0, -newFallingSpeed, 0);
        }
    }

    public string GetIngredientName() {
        return ingredientName;
    }

    //**ANIMATIONS
    //Feel free att även ändra saker som terminalVelocity, rotating osv för att få en bra animation! <<<<<<<<<<<<<
    public void AnimationDie() {
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f); //temporärt innan animation finns
        newFallingSpeed = 1;
        animator.SetTrigger("Die"); 
    }

    public void AnimationCaught() { //Ingredienser blir destroyed innan denna animation blir spelad så det måste fixas om det ska animeras, skriv till Linus :)
        animator.SetTrigger("Caught"); 
    }
}
