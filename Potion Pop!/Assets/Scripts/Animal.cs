using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [Header ("Time for animal to celebrate being cured")]
    [SerializeField] private float timeForCured;
    [Header("Time for animal to walk away after being cured")]
    [SerializeField] private float timeForHappyWalking;
    [Header("Time for animal to walk to the next spot in queue")]
    [SerializeField] private float timeToMoveInQueue;
    [SerializeField] private float speed;
    [SerializeField] private float duration;
    [SerializeField] private GameObject animalStanding;
    [SerializeField] private GameObject animalSitting;
    [SerializeField] private Animator animalStandingAnimator;
    [SerializeField] private Animator animalSittingAnimator;
    private Vector3 targetPos;
    private bool isFirstInQueue;
    
    private void Start()
    {
        //animalStandingAnimator = animalStanding.gameObject.GetComponent<Animator>();
        //animalSittingAnimator = animalSitting.gameObject.GetComponent<Animator>();
        
        StartCoroutine(CheckIfIsFirst(0.2f)); 
    }
    

    IEnumerator CheckIfIsFirst(float timeToWait) 
    {
        yield return new WaitForSeconds(timeToWait);
        if (isFirstInQueue == true)
        {
            animalStanding.SetActive(false);
            animalSitting.SetActive(true);
            //animalSittingAnimator.SetTrigger("SittingSad");
        }
        else
        {
            animalStanding.SetActive(true);
            animalSitting.SetActive(false);
            //animalStandingAnimator.SetTrigger("StandingSad");
        }
    }

    public void CureAnimal()
    {
        StartCoroutine(CureAnimalCoroutine());
    }
    IEnumerator CureAnimalCoroutine()
    {
        StartCoroutine(CuredAnimationCoroutine(timeForCured, timeForHappyWalking));
        yield return new WaitForSeconds(timeForCured);
        //röra på djuret förut
        StartCoroutine(LerpMovePosition(targetPos, 5));
    }

    

    
    private IEnumerator CuredAnimationCoroutine(float timeForCured, float timeForHappyWalking) {

        //animalSitting.SetActive(true);
        //animalStanding.SetActive(false);
        animalSittingAnimator.SetTrigger("SittingHappy");
        yield return new WaitForSeconds(timeForCured);
        animalSitting.SetActive(false);
        animalStanding.SetActive(true);
        animalStandingAnimator.SetTrigger("WalkingHappy");
        Vector3 startPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        targetPos = new Vector3(startPos.x - 5, startPos.y, startPos.z);
        yield return new WaitForSeconds(timeForHappyWalking); 
    }
    

    public void MoveAnimal()
    {
        StartCoroutine(MoveAnimalQueueCoroutine(timeToMoveInQueue));
        Vector3 startPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        targetPos = new Vector3(startPos.x - 2, startPos.y, startPos.z);
        StartCoroutine(LerpMovePosition(targetPos, 5));
    }
    private IEnumerator LerpMovePosition(Vector3 targetPosition, float duration)
    {
        animalStanding.SetActive(true);
        //animalStanding.gameObject.GetComponent<Animator>().SetTrigger("WalkingSad");
        animalStandingAnimator.SetTrigger("WalkingSad");
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

    private IEnumerator MoveAnimalQueueCoroutine(float timeToMoveInQueue)
    {
        if (isFirstInQueue == true)
        {
            animalStandingAnimator.SetTrigger("WalkingSad");
            yield return new WaitForSeconds(timeToMoveInQueue);
            animalSitting.SetActive(true);
            animalStanding.SetActive(false);
            animalSittingAnimator.SetTrigger("SittingSad");
        }
        else
        {
            animalStandingAnimator.SetTrigger("WalkingSad");
            yield return new WaitForSeconds(timeToMoveInQueue);
            animalStandingAnimator.SetTrigger("StandingSad");
        }
    }

    public void SetIsFirstInQueueTrue()
    {
        isFirstInQueue = true;
    }
    public void SetIsFirstInQueueFalse()
    {
        isFirstInQueue = false;
    }
}
