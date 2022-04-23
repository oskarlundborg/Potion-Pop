using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {

    public LevelData_Linus level;
    private Emitter_Movement emitter_Movement;

    private Transform spawnPos;
    private float timer;

    private float spawnTime;
    public float minSpawnTime;
    public float maxSpawnTime;

    [Header("Spawning states")]
    [SerializeField] private float chanceSwitchToWave = 7f;
    [SerializeField] private float chanceSwitchToRandom = 22f;
    [SerializeField] private float chanceForDouble = 25f;
    [SerializeField] private float chanceForTriple = 15f;
    private bool isWaveSpawn = false;

    [Header("Frenzy!")]
    [Tooltip("Hur stor chans (av 100) att det blir frenzy efter varje spawn")] public float chanceForSpawnFrenzy = 3f;
    [Tooltip("Tid mellan varje spawn i frenzy")] public float spawnFrenzyTime = 3f;
    [Tooltip("Hur många saker som ska spawna i frenzy")] public float spawnFrenzyAmount = 10f;
    private float spawnFrenzyCount = 0f;
    private bool isFrenzy = false;

    void Start() {
        emitter_Movement = GetComponent<Emitter_Movement>();
        spawnPos = GetComponent<Transform>();
        spawnTime = minSpawnTime;

        if (spawnFrenzyTime <= 0) {
            spawnFrenzyTime = minSpawnTime / 3;
        }

        emitter_Movement = GetComponent<Emitter_Movement>();

        //Debug feedback
        if (level.ingredientsToSpawn[0] == null) {
            Debug.Log("ERROR: Fyll GameObject \"Emitter\" med ingredienser");
        }

    }

    void Update() {
        timer += Time.deltaTime;
        
        if (timer > spawnTime && level.ingredientsToSpawn[0] != null && !isFrenzy) { //Spawnblocket
            RandomChecks();

            if(!isWaveSpawn) {
                RandomSpawn();
            } else {
                Instantiate(level.ingredientsToSpawn[Random.Range(0, level.ingredientsToSpawn.Length)], spawnPos.position, spawnPos.rotation); //Spawna random ingrediens
            }                        
            spawnTime = Random.Range(minSpawnTime, maxSpawnTime); //Ny random spawnTime                
            timer = 0f; //Reset time
        }
        if (isFrenzy && (timer > spawnFrenzyTime)) { //Om det är frenzy och timer överskrider spawnFrenzyTime
            FrenzyTime();
        }
    }

    private void RandomChecks() { //Ska det bli frenzy eller byta spawn mönster?
        if (chanceSwitchToRandom >= Random.Range(0, 100) && isWaveSpawn == true) { isWaveSpawn = false; }

        if (chanceSwitchToWave >= Random.Range(0, 100) && isWaveSpawn == false) { isWaveSpawn = true; }

        if (chanceForSpawnFrenzy >= Random.Range(0, 100)) { isFrenzy = true; }
    }
   
    private void RandomSpawn() {
        Vector3 randomizedPos = RandomSpawnPos();
        Instantiate(level.ingredientsToSpawn[Random.Range(0, level.ingredientsToSpawn.Length)], randomizedPos, spawnPos.rotation);

        if(chanceForDouble >= Random.Range(0, 100)) {
            randomizedPos = RandomSpawnPos();
            Instantiate(level.ingredientsToSpawn[Random.Range(0, level.ingredientsToSpawn.Length)], randomizedPos, spawnPos.rotation);

            if(chanceForTriple >= Random.Range(0, 100)) {
                randomizedPos = RandomSpawnPos();
                Instantiate(level.ingredientsToSpawn[Random.Range(0, level.ingredientsToSpawn.Length)], randomizedPos, spawnPos.rotation);
            }
        }
    }

    private void FrenzyTime() {
        Instantiate(level.ingredientsToSpawn[Random.Range(0, level.ingredientsToSpawn.Length)], spawnPos.position, spawnPos.rotation); //Spawna random ingrediens
        spawnFrenzyCount++; //När detta blir lika med spawnFrenzyAmount(som väljs i inspector) - 1 så slutar frenzy
        timer = 0f;

        if (spawnFrenzyCount >= spawnFrenzyAmount - 1) {
            isFrenzy = false;
            spawnFrenzyCount = 0;
            Debug.Log("Not frenzy!");
        }
    }

    private Vector3 RandomSpawnPos() {
        float x = Random.Range(emitter_Movement.leftTopCorner.x, emitter_Movement.rightTopCorner.x);
        float y = Random.Range(gameObject.transform.position.y + 0.15f, gameObject.transform.position.y - 0.15f);
        Vector3 randomizedPos = new Vector3(x, y, emitter_Movement.leftTopCorner.z);
        return randomizedPos;
    }
}
