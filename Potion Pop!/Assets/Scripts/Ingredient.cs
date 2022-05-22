using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    private LevelState level;
    private bool isInRecipe;
    private bool isPowerup;
    private ParticleSystem.MainModule settings;
    private ParticleSystem particles;

    [SerializeField] private string ingredientName;

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
    private Transform cauldron;

    void Start() {
        powerUpState = GameObject.FindGameObjectWithTag("PowerUpState").GetComponent<PowerUpState>();
        cauldron = GameObject.Find("Cauldron").GetComponent<BoxCollider2D>().GetComponent<Transform>();
        level = GameObject.Find("LevelState").GetComponent<LevelState>();
        particles = gameObject.GetComponent<ParticleSystem>();
        settings = gameObject.GetComponent<ParticleSystem>().main;
        animator = gameObject.GetComponent<Animator>();

        newFallingSpeed = fallingSpeed;

        //Väljer randomly hur snabbt objektet ska rotera
        rotateSpeed = Random.Range(minSpeed, maxSpeed);
        newRotateSpeed = rotateSpeed;

        foreach(GameObject go in level.recipeIngredients) { //Is good ingredient?
            if (go.GetComponent<Ingredient>().GetIngredientName() == ingredientName) {
                isInRecipe = true;
            } 
        }
        foreach (GameObject go in level.powerups) { //Is good powerup?
            if (go.GetComponent<Ingredient>().GetIngredientName() == ingredientName) {
                isPowerup = true;
            }
        }

        if (isInRecipe || isPowerup) {
            settings.startColor = new ParticleSystem.MinMaxGradient(new Color(0, 1, 0, 0.5f));
        }
        particles.Play();

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
        if (powerUpState.powerUpState == 4 && (gameObject.transform.position.y - cauldron.position.y) > -0.1f &&
            isInRecipe) { //isMagnetState? 
            MagnetMovement();
        } else {
            rb.velocity = new Vector3(0, -newFallingSpeed, 0);
        }
    }

    private void MagnetMovement() {
        Vector3 magnetPoint = new Vector3(cauldron.position.x, cauldron.position.y + 0.5f, cauldron.position.z);
        transform.position = Vector3.MoveTowards(transform.position, magnetPoint,
            (newFallingSpeed * 2) * Time.deltaTime);
    }

    public string GetIngredientName() {
        return ingredientName;
    }

    //**ANIMATIONS
    //Feel free att även ändra saker som terminalVelocity, rotating osv för att få en bra animation! <<<<<<<<<<<<<
    public void AnimationDie() {
        particles.Clear(true);
        gameObject.GetComponent<ParticleSystem>().Stop();
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f); //temporärt innan animation finns
        newFallingSpeed = 0.5f;
        animator.SetTrigger("Die");
    }

    public void AnimationCaught() { //Ingredienser blir destroyed innan denna animation blir spelad så det måste fixas om det ska animeras, skriv till Linus :)
        animator.SetTrigger("Caught"); 
    }
}
