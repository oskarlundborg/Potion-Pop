using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter_Movement : MonoBehaviour
{
    public float chanceForNewRandomSpawnPoint = 20f;

    public Vector3 leftTopCorner;
    public Vector3 rightTopCorner;

    [Range(0, 0.2f)] public float yOffset = 0.1f;
    [Range(0, 0.15f)] public float xOffset = 0.05f;

    public float speed = 1.0f;
    
    void Start() {
        leftTopCorner = Camera.main.ViewportToWorldPoint(new Vector3(0f + xOffset, 1f + yOffset, 1));
        rightTopCorner = Camera.main.ViewportToWorldPoint(new Vector3(1f - xOffset, 1f + yOffset, 1));
    }

    void Update() {
        transform.position = Vector3.Lerp(leftTopCorner, rightTopCorner, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
        
    }

}
 

