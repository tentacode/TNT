using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public GameObject audioSourcePrefab;
    public AudioSource musicSource;

    [Header("Musics")]
    public AudioClip gameMusic;

    [Header("FX")]
    public AudioClip fireLazer;
    public AudioClip bounceWall;
    public AudioClip bounceShield;

	void Start ()
	{
		musicSource.clip = gameMusic;
        musicSource.volume = 0.1f;
		musicSource.Play ();
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.W)) {
			PlayClip (fireLazer, new Vector3(-4.7f,0,0));
		}
		if (Input.GetKeyDown (KeyCode.X)) {
			PlayClip (fireLazer, new Vector3(0,0,0));
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			PlayClip (fireLazer, new Vector3(4.7f,0,0));
		}
	}

    public void PlayClip(AudioClip clip, Vector3 position, float volume = 1.0f)
	{
		GameObject sourceGameObject = (GameObject)Instantiate (
			audioSourcePrefab, 
			position, 
			Quaternion.identity
		);

		AudioSource source = sourceGameObject.GetComponent<AudioSource> ();
        source.volume = volume;
		source.clip = clip;
		source.Play ();

		Destroy (sourceGameObject, clip.length + 0.1f);
	}
}
