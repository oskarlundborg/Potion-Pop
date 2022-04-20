using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron_Mouth : MonoBehaviour
{

    public LevelData_Linus level;

    private void OnTriggerEnter2D(Collider2D collision) {
        //Testar om det �r sorten Ingredient
        if (collision.CompareTag("Ingredient")) {
            bool correctWasFound = false;

            for (int i = 0; i < level.ingredientsToCollect.Length; i++) { //loopar genom ingredientsToCollect

                //Testar om ingrediensen som hamnade i cauldronen finns i ingrediensToCollect
                if (level.ingredientsToCollect[i].GetComponent<Ingredient>().ingredientName == collision.GetComponent<Ingredient>().ingredientName) {
                    level.ingredientsToCollect[i].GetComponent<Ingredient>().IncreaseTimesCollected();
                    
                    Debug.Log("R�tt!");

                    correctWasFound = true;
                }
            }
            if(!correctWasFound) {
                Debug.Log("Fel!");
                //negativ effekt
            }
        }

        //testa efter andra grejer, till exempel Bomb?


            //Ist�llet f�r destroy, g�r det flesta av spelobjektets egenskaper inaktiva f�r animation
            //Animation exempel. Krymp ingrediensen
            Destroy(collision.gameObject);
       
    }
    
}
