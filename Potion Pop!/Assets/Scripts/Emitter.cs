using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {

    //public LevelData level;
    public LevelData_Linus level;


    private Transform spawnPos;
    private float timer;

    // Start is called before the first frame update
    void Start() {
        spawnPos = GetComponent<Transform>();

        //Debug feedback
        if (level.ingredientsToSpawn[0] == null) {
            Debug.Log("ERROR: Fyll GameObject \"Emitter\" med ingredienser");
        }

    }

    // Update is called once per frame
    void Update() {

        timer += Time.deltaTime;
        if (timer > 1f && level.ingredientsToSpawn[0] != null) {
            Instantiate(level.ingredientsToSpawn[Random.Range(0, level.ingredientsToSpawn.Length)], spawnPos.position, spawnPos.rotation);
            timer = 0f;
        }

    }
}
