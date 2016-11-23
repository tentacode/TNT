using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LazerSpawner : MonoBehaviour
{
    public GameObject lazerPrefab;
    public List<Texture> textures;
    public List<Color> colors;
    public float minTime;
    public float maxTime;

    public Vector2 minPosition;
    public Vector2 maxPosition;

	void Start ()
    {
        Invoke ("Spawn", 2.0f);
	}

    void Spawn()
    {
        Vector2 position = new Vector2 (
            Random.Range (minPosition.x, maxPosition.x),
            Random.Range (minPosition.y, maxPosition.y)
        );

        GameObject lazer = (GameObject)Instantiate (lazerPrefab, position, Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
        lazer.GetComponent<LazerBehavior> ().Mute();
        lazer.GetComponent<LazerBehavior> ().maxBounces = 4;

        int randomIndex = Random.Range (0, 4);
        lazer.transform.GetChild(0).GetComponent<Renderer>().material.mainTexture = textures[randomIndex];
        lazer.transform.GetChild(0).GetChild(0).GetComponent<ParticleSystem>().startColor = colors[randomIndex];

        Invoke ("Spawn", Random.Range(minTime, maxTime));
    }
}
