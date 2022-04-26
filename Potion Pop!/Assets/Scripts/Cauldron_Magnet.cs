using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron_Magnet : MonoBehaviour
{

    [HideInInspector] public List<Rigidbody2D> rbs = new List<Rigidbody2D>();

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach(Rigidbody2D rb in rbs) {
            Vector3 magnetPoint = new Vector3(rb.position.x - transform.position.x, rb.position.y, 0);
            rb.velocity = new Vector3(magnetPoint.x * -3, rb.velocity.y, 0);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Ingredient")) {
            rbs.Add(collision.GetComponent<Rigidbody2D>());
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Ingredient")) {
            rbs.Remove(other.GetComponent<Rigidbody2D>());
        }
    }
}
