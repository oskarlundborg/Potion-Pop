using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter_Movement : MonoBehaviour
{
    private Emitter emitter;
    public float chanceForNewRandomSpawnPoint = 20f;

    private Vector3 leftTopCorner;
    private Vector3 rightTopCorner;

    [Range(0, 0.2f)] public float yOffset = 0.1f;
    [Range(0, 0.15f)] public float xOffset = 0.05f;

    public float speed = 1.0f;
    private float startSpeed;
    
    void Start() {
        emitter = GetComponent<Emitter>();

        startSpeed = speed;

        leftTopCorner = Camera.main.ViewportToWorldPoint(new Vector3(0f + xOffset, 1f + yOffset, 1));
        rightTopCorner = Camera.main.ViewportToWorldPoint(new Vector3(1f - xOffset, 1f + yOffset, 1));
    }

    void Update() {

        transform.position = Vector3.Lerp(leftTopCorner, rightTopCorner, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
        
    }

    //lite udda s�tt men var l�ttast f�r mig, detta �ndrar speedet p� emitter s� att n�sta ingrediens spawnar p� ett nytt st�lle och inte alltid f�ljer samma v�g-r�relse
    public void RandomizeSpawn() {
        speed = Random.Range(10, 300);
        Debug.Log("RandomizeSpawn");
        Debug.Log(speed);
        StartCoroutine(Waiter());
        speed = startSpeed;
        Debug.Log(speed);
    }
    IEnumerator Waiter() {
        yield return new WaitForSeconds(0.2f);
    }
}
 

