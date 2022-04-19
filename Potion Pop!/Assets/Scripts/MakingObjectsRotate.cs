using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakingObjectsRotate : MonoBehaviour
{
    public float speed = 100.0f;

    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);
    }
}