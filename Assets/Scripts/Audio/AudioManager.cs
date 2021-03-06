﻿using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public GameObject audioSourcePrefab;
    public AudioSource musicSource;

    [Header("Mixer groups")]
    public AudioMixerGroup masterMixerGroup;
    public AudioMixerGroup voicseMixerGroup;

    [Header("Musics")]
    public AudioClip introMusic;
    public AudioClip gameMusic;

    [Header("FX")]
    public AudioClip fireLazer1;
    public AudioClip fireLazer2;
    public AudioClip fireLazer3;
    public AudioClip fireLazer4;
    public AudioClip StrangerDeath;
    public AudioClip AlienBearDeath;
    public AudioClip Scrap;
    public AudioClip Hunter;
    public AudioClip bounceWall;
    public AudioClip bounceShield;
    public AudioClip reload;

    private bool battleMusicPlaying = false;

    void Start ()
    {
        // looking for other AudioManager
        GameObject[] audioManagers;
        audioManagers = GameObject.FindGameObjectsWithTag("AudioManager");

        if (audioManagers.Length > 1) {
            Destroy (gameObject);
        } else {
            DontDestroyOnLoad (gameObject);
        }
    }

    public void TriggerIntroMusic()
    {
        if (battleMusicPlaying) {
            PlayIntroMusic ();
        } else {
            Invoke ("PlayIntroMusic", 1.0f);
        }
    }

    void PlayIntroMusic()
    {   
        musicSource.clip = introMusic;
        musicSource.volume = 0.2f;
        musicSource.Play ();
    }

    public void PlayBattleMusic()
    {
        if (battleMusicPlaying) {
            return;
        }

        battleMusicPlaying = true;
        musicSource.clip = gameMusic;
        musicSource.volume = 0.1f;
        musicSource.Play ();
    }

    public void PlayClip(AudioClip clip, Vector3 position, float volume = 1.0f, float pitch = 1.0f, AudioMixerGroup mixerGroup = null)
	{
		GameObject sourceGameObject = (GameObject)Instantiate (
			audioSourcePrefab, 
			position, 
			Quaternion.identity
		);

		AudioSource source = sourceGameObject.GetComponent<AudioSource> ();
        source.pitch = pitch;
        source.volume = volume;
		source.clip = clip;
        source.outputAudioMixerGroup = (mixerGroup == null) ? masterMixerGroup : mixerGroup;
		source.Play ();

		Destroy (sourceGameObject, clip.length + 0.1f);
	}
}
