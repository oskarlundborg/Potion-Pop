using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalQueue : MonoBehaviour
{
    //En array av GameObjects med de djur som ska stå i kön
    //En levelstate som vet hur många djur som har räddats
    [SerializeField] private GameObject[] animalsToSaveArray;
    [SerializeField] private LevelState levelState;
    [SerializeField] private float waitTime = 1f;


    private void Start()
    {
        animalsToSaveArray[0].GetComponent<Animal>().SetIsFirstInQueueTrue();
       // animalsToSaveArray[0].GetComponent<Animal>().CheckIfIsFirst();
        Debug.Log("first in line = " + animalsToSaveArray[0]);
    }

    public void TreatAnimals()
    {
        StartCoroutine(SaveAnimalCoroutine(waitTime));
    }
    private void MoveAnimalQueue()
    {
        foreach (GameObject animal in animalsToSaveArray) {
            if (animal != null) {
                animal.GetComponent<Animal>().MoveAnimal();
            }
        }
    }

    private void CureAnimal()
    {
        if (animalsToSaveArray[0] != null)
        {
            animalsToSaveArray[0].GetComponent<Animal>().CureAnimal();
        }
        
        for (int i = 1; i < animalsToSaveArray.Length; i++) {
            animalsToSaveArray[i - 1] = animalsToSaveArray[i];
        }
        for (int i = animalsToSaveArray.Length - 1; i > 0; i--) {
            if (animalsToSaveArray[i] == animalsToSaveArray[i - 1]) {
                animalsToSaveArray[i] = null;
            }
        }
        if (animalsToSaveArray[0] != null)
        {
            animalsToSaveArray[0].GetComponent<Animal>().SetIsFirstInQueueTrue();
        }  
    }

    IEnumerator SaveAnimalCoroutine(float timeToWait) {
        CureAnimal();
        yield return new WaitForSeconds(timeToWait);
        MoveAnimalQueue();
    }
    //MetodMoveQueue
    // när saved animal = 1 ska djurets på plats 1 i arrayen sjukanimation gå över till ett moldpuff, sen den glada animationen.

    //IEnumerator
    //Friska djuret går
    //MoveRestOfQue
    //i varje djur, MovePositionToLeft()
    //trycka fram alla gameObjekts i arrayen så att [0] är det som var andra djuret

   
}
