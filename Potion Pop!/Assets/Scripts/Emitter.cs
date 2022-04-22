using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {

    //public LevelData level;
    public LevelData_Linus level;
    private Emitter_Movement emitter_Movement;

    private Transform spawnPos;
    private float timer;

    private float spawnTime;
    public float minSpawnTime;
    public float maxSpawnTime;

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

        //Debug feedback
        if (level.ingredientsToSpawn[0] == null) {
            Debug.Log("ERROR: Fyll GameObject \"Emitter\" med ingredienser");
        }

    }

    void Update() {
        timer += Time.deltaTime;

        //Spawnblocket
        if (timer > spawnTime && level.ingredientsToSpawn[0] != null && !isFrenzy) {
            Instantiate(level.ingredientsToSpawn[Random.Range(0, level.ingredientsToSpawn.Length)], spawnPos.position, spawnPos.rotation); //Spawna random ingrediens
            spawnTime = Random.Range(minSpawnTime, maxSpawnTime); //Ny random spawnTime    
            timer = 0f; //Reset time
            RandomChecks();
        }

        if (isFrenzy && (timer > spawnFrenzyTime)) { //Om det är frenzy och timer överskrider spawnFrenzyTime
            FrenzyTime();
        }
    }

    private void RandomChecks() { //Ska det bli frenzy eller byta spawn ställe?
        if (emitter_Movement.chanceForNewRandomSpawnPoint >= Random.Range(0, 100)) { //Randomly väljer om det ska bli en ny spawn plats
        }

        if (chanceForSpawnFrenzy >= Random.Range(0, 100)) { //Randomly väljer om det blir frenzy
            isFrenzy = true;
            Debug.Log("Frenzy!");
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

}
