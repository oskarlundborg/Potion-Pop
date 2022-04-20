using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        //Vem som helst är välkommen att göra en fin animation istället för att direkt göra destroy! :)
        Destroy(collision.gameObject);
    }
}
