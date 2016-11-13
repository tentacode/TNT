using UnityEngine;
using System.Collections;

public class musicIntro : MonoBehaviour {
    public GameObject audioSourcePrefab;
    public AudioSource musicSource;

    [Header("Musics")]
    public AudioClip itroMusic;
    // Use this for initialization
    void Start () {
        musicSource.clip = itroMusic;
        musicSource.volume = 0.1f;
        musicSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
