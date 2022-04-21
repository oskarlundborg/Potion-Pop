using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {

    //public LevelData level;
    public LevelData_Linus level;


    private Transform spawnPos;
    private float timer;

    private float spawnTime;
    public float minSpawnTime;
    public float maxSpawnTime;

    public float chanceForSpawnFrenzy;
    public float spawnFrenzyTime = 3f;
    public float spawnFrenzyAmount = 10f;
    private float spawnFrenzyCount = 0f;
    private bool isFrenzy = false;


    // Start is called before the first frame update
    void Start() {
        spawnPos = GetComponent<Transform>();

        spawnTime = minSpawnTime;

        if (spawnFrenzyTime == 0) {
            spawnFrenzyTime = minSpawnTime / 2;
        }

        //Debug feedback
        if (level.ingredientsToSpawn[0] == null) {
            Debug.Log("ERROR: Fyll GameObject \"Emitter\" med ingredienser");
        }

    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;
        if (timer > spawnTime && level.ingredientsToSpawn[0] != null && !isFrenzy) {
            Instantiate(level.ingredientsToSpawn[Random.Range(0, level.ingredientsToSpawn.Length)], spawnPos.position, spawnPos.rotation);

            spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            Debug.Log("Test"); 
            

            timer = 0f;
            if (chanceForSpawnFrenzy >= Random.Range(0,100)) {
                isFrenzy = true;
                Debug.Log("frenzy!");
            }
        }

        if(isFrenzy && (timer > spawnFrenzyTime)) {
            Instantiate(level.ingredientsToSpawn[Random.Range(0, level.ingredientsToSpawn.Length)], spawnPos.position, spawnPos.rotation);
            spawnFrenzyCount++;
            timer = 0f;
            if (spawnFrenzyCount >= spawnFrenzyAmount) {
                isFrenzy = false;
                spawnFrenzyCount = 0;
                Debug.Log("not frenzy!");
            }
        }
    }
}
