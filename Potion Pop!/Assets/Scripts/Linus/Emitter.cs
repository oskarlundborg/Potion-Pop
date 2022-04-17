using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{

    [SerializeField] private GameObject[] ingredients;
    
    private Transform spawnPos;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() {

        timer += Time.deltaTime;
        if(timer > 1f) {
            Instantiate(ingredients[0], spawnPos.position, spawnPos.rotation);
            timer = 0f;
        }
        
    }
}
