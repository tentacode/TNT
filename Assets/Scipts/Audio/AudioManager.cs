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
    public AudioClip bumpLazer;
    public AudioClip hitPlayer;
    public AudioClip deadPlayer;

	void Start ()
	{
		musicSource.clip = gameMusic;
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

	public void PlayClip(AudioClip clip, Vector3 position)
	{
		GameObject sourceGameObject = (GameObject)Instantiate (
			audioSourcePrefab, 
			position, 
			Quaternion.identity
		);

		AudioSource source = sourceGameObject.GetComponent<AudioSource> ();
		source.clip = clip;
		source.Play ();

		Destroy (sourceGameObject, clip.length + 0.1f);
	}
}
