using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    private Rigidbody2D rigidBody;


    private void Start()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(0, -speed);
    }
}


