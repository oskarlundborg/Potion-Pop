using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron_Magnet : MonoBehaviour
{
    private LevelState level;
    private GameObject cauldron;
    private Transform emitterPos;
    private Transform posDif;
    [HideInInspector] public List<Rigidbody2D> rbs = new List<Rigidbody2D>();

    private void Start() {
        level = GameObject.Find("LevelState").GetComponent<LevelState>();
        cauldron = GameObject.Find("Cauldron");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach(Rigidbody2D rb in rbs) {
            
            /*
            Vector3 magnetPoint = new Vector3(rb.position.x - transform.position.x, rb.position.y, 0);
            rb.velocity = new Vector3(magnetPoint.x * -3, rb.velocity.y, 0);
            */


            /*
            Transform pos = cauldron.transform;
            Vector3 magnetPoint = new Vector3(pos.position.x, pos.position.y, 0);
            rb.velocity = new Vector3(Mathf.Clamp(magnetPoint.x, 0, 1), Mathf.Clamp(magnetPoint.y, 0, 1), 0);
            */

        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Ingredient")) {
            foreach(GameObject go in level.ingredientsToSpawn) { //Check if good ingredient
                if (collision.GetComponent<Ingredient>().GetIngredientName() == go.GetComponent<Ingredient>().GetIngredientName()) {
                    rbs.Add(collision.GetComponent<Rigidbody2D>());
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Ingredient")) {
            rbs.Remove(other.GetComponent<Rigidbody2D>());
        }
    }
}
