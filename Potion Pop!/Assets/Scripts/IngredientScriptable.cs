using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient", menuName = "Ingredient")]
public class IngredientScriptable : ScriptableObject 
{
    /*
    public string nameOfIngredient;
    public Sprite Sprite;
    public int maxSpeed;
    public int minSpeed;
    public int timesCollected;
    [SerializeField] private float terminalVelocity;
    private bool rotatesClockwise;
    private float speed;
    private Rigidbody2D rb;
    
    void Start()
    {

        //V?ljer randomly hur snabbt objektet ska rotera
        speed = Random.Range(minSpeed, maxSpeed);

        //V?ljer randomly vilket h?ll objektet ska rotera
        int temp = Random.Range(1, 10);
        if (temp % 2 == 0)
        {
            rotatesClockwise = false;
        }
        else
        {
            rotatesClockwise = true;
        }
    }

    
    void Update()
    {
        if (rotatesClockwise)
        {
            //transform.Rotate(Vector3.forward * Time.deltaTime * speed);
        }
        else
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * (speed * -1));
        }

    }

    
    public void IncreaseTimesCollected()
    {
        timesCollected++;
    }
    */
}
