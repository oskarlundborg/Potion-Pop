using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {

    public LevelState level;
    private Emitter_Movement emitter_Movement;

    private Transform spawnPos;
    private float timer;

    private float spawnTime;
    public float minSpawnTime;
    public float maxSpawnTime;

    private int[] ingredientSpawnCounter;
    private GameObject ingredientToSpawn;
    private int min, max, minIndex;

    [Header("Max difference for min and max spawned ingredient")]
    [Tooltip("Max difference for min and max spawned ingredient")] [SerializeField] private int spawnDiff = 2;

    [Header("Spawning states")]
    [SerializeField] private float chanceSwitchToWave = 7f;
    [SerializeField] private float chanceSwitchToRandom = 22f;
    [SerializeField] private float chanceForDouble = 25f;
    [SerializeField] private float chanceForTriple = 15f;
    private bool isWaveSpawn = false;

    [Header("Frenzy!")]
    [Tooltip("Hur stor chans (av 100) att det blir frenzy efter varje spawn")] public float chanceForSpawnFrenzy = 3f;
    [Tooltip("Tid mellan varje spawn i frenzy")] public float spawnFrenzyTime = 3f;
    [Tooltip("Hur m?nga saker som ska spawna i frenzy")] public float spawnFrenzyAmount = 10f;
    private float spawnFrenzyCount = 0f;
    private bool isFrenzy = false;

    [Header("Power-ups/debuffs")]
    [Tooltip("Chance (out of 100) that the next spawn is a special item")] public float chanceToSpawnSpecial = 1f;
    [Tooltip("Chance (out of 100) that the special spawn is a power-up")] public float powerupToDebuffRatio = 50f;
    private bool isSpecial = false;

    void Start() {
        emitter_Movement = GetComponent<Emitter_Movement>();
        spawnPos = GetComponent<Transform>();
        spawnTime = minSpawnTime;
        level = GameObject.Find("LevelState").GetComponent<LevelState>();
        ingredientSpawnCounter = new int[level.ingredientsToSpawn.Length];

        if (spawnFrenzyTime <= 0) {
            spawnFrenzyTime = minSpawnTime / 3;
        }

        emitter_Movement = GetComponent<Emitter_Movement>();

        //Debug feedback
        if (level.ingredientsToSpawn[0] == null) {
            Debug.Log("Fyll \"Level State\" med minst två ingredienser!");
            level.ingredientsToSpawn[0] = new GameObject("empty");
        }
        if (level.powerups[0] == null && level.debuffs[0] == null) {
            chanceToSpawnSpecial = 0;
        }
        if (level.powerups[0] == null) {
            level.powerups[0] = new GameObject("empty");
            powerupToDebuffRatio = 0;
        }
        if (level.debuffs[0] == null) {
            level.debuffs[0] = new GameObject("empty");
            powerupToDebuffRatio = 100;
        }
    }

    void Update() {
        if (level.GetIsLevelStarted()) {
            UpdateEmitter();
        }
    }

    private void UpdateEmitter() {
        timer += Time.deltaTime;

        //Spawnblocket
        if (timer > spawnTime && level.ingredientsToSpawn[0] != null && !isFrenzy) {
            RandomChecks(); //Should special event happen and Pick ingredient to spawn
            IngredientSpawnAlgorithm();
            if (isSpecial) {
                SpawnSpecial();
            } else if (!isWaveSpawn) {
                RandomSpawn();
            } else {
                Instantiate(ingredientToSpawn, spawnPos.position, spawnPos.rotation); //Spawna random ingrediens
            }
            spawnTime = Random.Range(minSpawnTime, maxSpawnTime); //Ny random spawnTime                
            timer = 0f; //Reset time
        }

        if (isFrenzy && (timer > spawnFrenzyTime)) { //Om det ?r frenzy och timer ?verskrider spawnFrenzyTime
            FrenzyTime();
        }
    }

    private void RandomChecks() { //Ska det bli frenzy eller byta spawn m?nster?
        if (chanceSwitchToRandom > Random.Range(0, 100) && isWaveSpawn == true) { isWaveSpawn = false; }

        if (chanceSwitchToWave > Random.Range(0, 100) && isWaveSpawn == false) { isWaveSpawn = true; }

        if (chanceForSpawnFrenzy > Random.Range(0, 100)) { isFrenzy = true; }

        if (chanceToSpawnSpecial > Random.Range(0, 100)) { isSpecial = true; }
    }

    private void RandomSpawn() {
        Vector3 randomizedPos = RandomSpawnPos();
        Instantiate(ingredientToSpawn, randomizedPos, spawnPos.rotation);

        if (chanceForDouble > Random.Range(0, 100)) {
            randomizedPos = RandomSpawnPos();
            Instantiate(ingredientToSpawn, randomizedPos, spawnPos.rotation);

            if (chanceForTriple > Random.Range(0, 100)) {
                randomizedPos = RandomSpawnPos();
                Instantiate(ingredientToSpawn, randomizedPos, spawnPos.rotation);
            }
        }
    }

    private void SpawnSpecial() {
        Vector3 randomizedPos = RandomSpawnPos();
        if (powerupToDebuffRatio > Random.Range(0, 100)) {
            Instantiate(level.powerups[Random.Range(0, level.powerups.Length)], randomizedPos, spawnPos.rotation);
        } else {
            Instantiate(level.debuffs[Random.Range(0, level.debuffs.Length)], randomizedPos, spawnPos.rotation);
        }
        isSpecial = false;
    }

    private void FrenzyTime() {
        Instantiate(ingredientToSpawn, spawnPos.position, spawnPos.rotation); //Spawna random ingrediens
        spawnFrenzyCount++; //N?r detta blir lika med spawnFrenzyAmount(som v?ljs i inspector) - 1 s? slutar frenzy
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

    private void IngredientSpawnAlgorithm() {
        int random = Random.Range(0, level.ingredientsToSpawn.Length);

        for (int i = 0; i < ingredientSpawnCounter.Length; i++) {
            if (min > ingredientSpawnCounter[i]) {
                min = ingredientSpawnCounter[i];
                minIndex = i;
            }
            if (max < ingredientSpawnCounter[i]) {
                max = ingredientSpawnCounter[i];
            }
        }        
        if (ingredientSpawnCounter[minIndex] + spawnDiff < max) {
            ingredientToSpawn = level.ingredientsToSpawn[minIndex]; //Om minst spawnade ingrediensen är för långt bak
            ingredientSpawnCounter[minIndex] += 1;
        } else {
            ingredientToSpawn = level.ingredientsToSpawn[random];
            ingredientSpawnCounter[random] += 1;
        }
    }
}
