using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        //Vem som helst �r v�lkommen att g�ra en fin animation ist�llet f�r att direkt g�ra destroy! :)
        Destroy(collision.gameObject);
    }
}
