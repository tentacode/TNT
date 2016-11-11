using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject lazerPrefab;

    private Sprite lazerColor;

	void Start ()
    {
        lazerColor = GetComponent<PlayerIdentity> ().lazerColor;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")) {
            GameObject lazer = (GameObject)Instantiate (lazerPrefab, spawnPoint.position, spawnPoint.rotation);
            lazer.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = lazerColor;
        }
	}
}
