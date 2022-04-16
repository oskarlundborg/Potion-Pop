using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron_Movement_Isabel : MonoBehaviour
{
    private float cauldronPosY;
    [SerializeField] private GameObject ingredientType1;
    
    

    void Start() 
    { 
        cauldronPosY = transform.position.y; 
    }

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x, cauldronPosY); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Melon")) {
            Debug.Log("Melon caught");
        }
    }
}
