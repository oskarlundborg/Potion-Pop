using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inactivezone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Ingredient")) {
            collision.GetComponent<Ingredient>().AnimationDie();
        }
    }
}
