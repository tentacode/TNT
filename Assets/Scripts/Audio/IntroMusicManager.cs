﻿using UnityEngine;
using System.Collections;

public class IntroMusicManager : MonoBehaviour
{
	void Awake ()
    {
        // looking for other IntroMusicManager
        GameObject[] musicManagers;
        musicManagers = GameObject.FindGameObjectsWithTag("MusicManager");

        if (musicManagers.Length > 1) {
            Destroy (gameObject);
        } else {
            DontDestroyOnLoad (gameObject);
            Invoke ("Play", 1.0f);
        }
	}

    void Play()
    {
        GetComponent<AudioSource> ().Play ();
    }
}
