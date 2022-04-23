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
    private float speed;

    [Header("Falling speed")]
    public float terminalVelocity = 2f;
    private Rigidbody2D rb;

    void Start() {
        animator = gameObject.GetComponent<Animator>();

        //Väljer randomly hur snabbt objektet ska rotera
        speed = Random.Range(minSpeed, maxSpeed);

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
            transform.Rotate(Vector3.forward * Time.deltaTime * speed);
        } else {
            transform.Rotate(Vector3.forward * Time.deltaTime * (speed * -1));
        }

    }

    void FixedUpdate() { 
        if (rb.velocity.magnitude > terminalVelocity) { //Falling
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, terminalVelocity);
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
        animator.SetTrigger("Die"); 
    }

    public void AnimationCaught() { //Ingredienser blir destroyed innan denna animation blir spelad så det måste fixas om det ska animeras, skriv till Linus :)
        animator.SetTrigger("Caught"); 
    }
}
