using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public GameObject audioSourcePrefab;
    public AudioSource musicSource;

    [Header("Musics")]
    public AudioClip gameMusic;

    [Header("FX")]
    public AudioClip fireLazer1;
    public AudioClip fireLazer2;
    public AudioClip fireLazer3;
    public AudioClip fireLazer4;
    public AudioClip bounceWall;
    public AudioClip bounceShield;

	void Start ()
	{
		musicSource.clip = gameMusic;
        musicSource.volume = 0.1f;
		musicSource.Play ();
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
