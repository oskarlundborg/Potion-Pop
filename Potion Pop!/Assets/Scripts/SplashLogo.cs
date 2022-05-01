using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashLogo : MonoBehaviour
{
    [SerializeField] LevelLoader levelLoader;

    private void Update()
    {
        levelLoader.LoadMainMenu();
    }
}
