using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float minSpeed = 40f;
    public float maxSpeed = 150f;

    private bool rotatesClockwise;
    private float speed;

    void Start() {

        //V�ljer randomly hur snabbt objektet ska rotera
        speed = Random.Range(minSpeed, maxSpeed);
        
        //V�ljer randomly vilket h�ll objektet ska rotera
        int temp = Random.Range(1, 10);
        if(temp % 2 == 0) {
            rotatesClockwise = false;
        } else {
            rotatesClockwise = true;
        }
    }

    void Update()
    {
        if(rotatesClockwise) {
            transform.Rotate(Vector3.forward * Time.deltaTime * speed);
        } else {
            transform.Rotate(Vector3.forward * Time.deltaTime * (speed * -1));
        }
        
    }
}