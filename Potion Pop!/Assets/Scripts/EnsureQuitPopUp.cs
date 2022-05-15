using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnsureQuitPopUp : MonoBehaviour
{
    [SerializeField] private GameObject popUp;

    public void EnsureQuitPopUpActivate() 
    {
        popUp.SetActive(true);    
    }

    public void OnNoButtonPressed() 
    {
        popUp.SetActive(false);
    }
}
