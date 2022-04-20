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

            //Istället för destroy, gör det flesta av spelobjektets egenskaper inaktiva för animation
            //Animation exempel. Krymp ingrediensen
            //Destroy(collision.gameObject);
       
    }
    
}
