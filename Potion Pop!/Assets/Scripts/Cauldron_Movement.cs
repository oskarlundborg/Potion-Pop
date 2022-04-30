using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron_Movement : MonoBehaviour {

    [SerializeField] private GameObject splashEffect;
    private float cauldronPosY;
    private Vector2 pos;
    private PowerUpState powerUpState;
    public LevelState levelState;
    private Cauldron_Magnet cauldron_Magnet;

    [Range(-2f, 5f)]
    [SerializeField] private float cauldronForceCameraBoundsOffset; //How far from camera edge can the cauldron be? 0 = half can be invisible 

    private bool isCauldronActive = true;

    void Start() {
        powerUpState = FindObjectOfType<PowerUpState>();
        cauldronPosY = transform.position.y; //Saves Y start position    
        cauldron_Magnet = GameObject.Find("Cauldron_Magnet").GetComponent<Cauldron_Magnet>();
        levelState = GameObject.Find("LevelState").GetComponent<LevelState>();
    }

    void Update() {
        if (powerUpState.powerUpState != 1 && levelState.GetIsLevelStarted() && Input.GetMouseButton(0)) { //Not frozen AND game is started AND touching
            MoveCauldron();
        }
    }

    private void MoveCauldron() {     
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x, cauldronPosY); //Cauldron follows cursor's x-pos 
        
        //Force cauldron in camera view
        Vector3 posCam = Camera.main.WorldToViewportPoint(transform.position);
        posCam.x = Mathf.Clamp(posCam.x, (cauldronForceCameraBoundsOffset / 10), 1 - (cauldronForceCameraBoundsOffset / 10));
        transform.position = Camera.main.ViewportToWorldPoint(posCam);
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(levelState.GetIsLevelStarted()) {
            if (collision.CompareTag("Ingredient")) { //Tests for ingredient
                collision.GetComponent<Ingredient>().AnimationCaught();
                levelState.AddIngredient(collision.GetComponent<Ingredient>().GetIngredientName());
                ActivateSplash();
            } else if (collision.CompareTag("Special")) {
                SpecialIdentifier(collision.GetComponent<Ingredient>().GetIngredientName());
            }

            //Bad for animation, fix later :P
            Destroy(collision.gameObject);
        }
    }
    //POWERUPS
    private void SpecialIdentifier(string name) {
        if (name == "ice") { //1
            powerUpState.SetIce();
        } else if (name == "slow") { //2
            powerUpState.SetSlow();
        } else if (name == "fast") { //3
            powerUpState.SetFast();
        } else if (name == "magnet") { //4
            powerUpState.SetMagnet();
        }

    }

    public void setFrozen() {
        GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.82f, 1f);
    }
    public void setUnfrozen() {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
    }

    private void ActivateSplash()
    {
        splashEffect.GetComponent<SplashEffect>().Splash();
    }
}
