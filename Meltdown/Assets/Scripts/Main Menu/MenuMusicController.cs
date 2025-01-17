﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicController : MonoBehaviour
{

    public AudioSource menuMusic;

    // Update is called once per frame
    void Update()
    {
        // Play music if it's enabled and not already playing
        if (menuMusic.isPlaying == false && GameSettings.music == true)
        {
            menuMusic.Play();
        } else if (menuMusic.isPlaying == true && GameSettings.music == false)
        {
            menuMusic.Stop();
        }
    }
}
