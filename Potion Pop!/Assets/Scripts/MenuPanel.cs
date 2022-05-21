using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private GameObject menuPopup;

    // Start is called before the first frame update
    void Start()
    {
        menuPopup.gameObject.SetActive(false);
    }

    public void OpenPopup()
    {
        menuPopup.gameObject.SetActive(true);
    }

    public void ClosePopup()
    {
        menuPopup.gameObject.SetActive(false);
    }

     



}

