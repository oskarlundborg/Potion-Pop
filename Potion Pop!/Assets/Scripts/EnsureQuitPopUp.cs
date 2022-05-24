using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnsureQuitPopUp : MonoBehaviour
{
    [SerializeField] private GameObject popUp;
    [SerializeField] private Image animal1;
    [SerializeField] private Image animal2;


    public void EnsureQuitPopUpActivate() 
    {
        popUp.SetActive(true);    
    }

    public void OnNoButtonPressed() 
    {
        popUp.SetActive(false);
    }
}
