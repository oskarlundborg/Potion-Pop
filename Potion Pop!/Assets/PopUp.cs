using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{

    public GameObject poUp;

    public void deactivatePopUp()
    {
        poUp.gameObject.SetActive(false);
    }

}
