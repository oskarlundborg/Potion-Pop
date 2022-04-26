using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private bool locked;
    public Image locker;
    public GameObject[] stars;
    public GameObject PopUp;
    private int counter = 0;

    public void Start()
    {
        PopUp.gameObject.SetActive(false);
        UpdateLevelImage();
    }

    public void UpdateLevelImage()
    {
        counter++;

        locker.gameObject.SetActive(!locked);
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].gameObject.SetActive(locked);
        }
        if(counter == 3) { PopUp.gameObject.SetActive(true);
            counter = 1;
        }
        locked = !locked;
     }

    


}
