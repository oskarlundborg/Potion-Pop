using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron_Mouth : MonoBehaviour
{

    public LevelData level;

    void Start()
    {
        
    }
    

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Ingredient")) {
            Debug.Log(collision);

            }

            //Ist�llet f�r destroy, g�r det flesta av spelobjektets egenskaper inaktiva f�r animation
            //Animation exempel. Krymp ingrediensen
            //Destroy(collision.gameObject);
       
    }
    
}
