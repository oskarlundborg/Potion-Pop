using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMusicAgain : MonoBehaviour
{
    private static BgMusicAgain bgMusic;

    void Awake()
    {
        if (bgMusic == null)
        {
            bgMusic = this;
            DontDestroyOnLoad(bgMusic);
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
