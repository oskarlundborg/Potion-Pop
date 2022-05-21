using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float duration;
    private Vector3 targetPos;
    //private float startTime;
    //private float distanceTotal;
    
    private void Start()
    {
        //startTime = Time.time;
        
    }
    public void CureAnimal()
    {
        Vector3 startPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        targetPos = new Vector3(startPos.x - 5, startPos.y, startPos.z);
        //animation IEnumerator
        StartCoroutine(LerpMovePosition(targetPos, 5));
    }

    
    IEnumerator CuredAnimationCoroutine(float timeForCured, float timeForHappy) {

        //animation cured
        yield return new WaitForSeconds(timeForCured);
        // animal happy
        yield return new WaitForSeconds(timeForHappy);

    }
    

    public void MoveAnimal()
    {
        Vector3 startPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        targetPos = new Vector3(startPos.x - 1, startPos.y, startPos.z);
        StartCoroutine(LerpMovePosition(targetPos, 5));
    }
    IEnumerator LerpMovePosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}
/*
    float time = 0;
    Vector3 startPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    targetPos = new Vector3(startPos.x - 1, startPos.y, startPos.z);
    while (time < duration)
    {
        //transform.position = Vector3.Lerp(startPos, targetPos, speed * Time.deltaTime);
        transform.position = Vector3.Lerp(startPos, targetPos, AnimationCurve.Eca)
        time += Time.deltaTime;
    }
    transform.position = targetPos;

    */

/*
Vector3 startPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

distanceTotal = Vector3.Distance(startPos, targetPos);
float distanceCovered = (Time.time - startTime) * speed;
float fractionOfJourney = distanceCovered / distanceTotal;
transform.position = Vector3.Lerp(startPos, targetPos, fractionOfJourney);
*/