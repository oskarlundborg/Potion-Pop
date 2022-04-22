using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron_Movement : MonoBehaviour
{
    private float cauldronPosY;
    private GameObject mouth;

    public LevelState levelState;

    [Range(-2f, 5f)]
    [SerializeField] private float cauldronForceCameraBoundsOffset; //How far from camera edge can the cauldron be? 0 = half can be invisible 


    void Start() 
    {
        mouth = transform.GetChild(0).gameObject;
        cauldronPosY = transform.position.y; //Saves Y start position        
    }

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x, cauldronPosY); //Cauldron follows cursor's x-pos 

        //Force cauldron in camera view
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, (cauldronForceCameraBoundsOffset / 10), 1 - (cauldronForceCameraBoundsOffset / 10));
        transform.position = Camera.main.ViewportToWorldPoint(pos);

    }

    //**ALLT HÄR HAR MED TRIGGER ATT GÖRA
    private void OnTriggerEnter2D(Collider2D collision) {
        //Testar om det är sorten Ingredient
        if (collision.CompareTag("Ingredient")) {
            collision.GetComponent<Ingredient>().AnimationCaught();
            //levelState.AddIngredient(collision.GetComponent<Ingredient>().ingredientName);
        }

        //Istället för destroy, gör det flesta av spelobjektets egenskaper inaktiva för animation            
        //Animation exempel. Krymp ingrediensen           
        Destroy(collision.gameObject);

    }
}
