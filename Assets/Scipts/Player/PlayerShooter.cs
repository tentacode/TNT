using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject lazerPrefab;

    private Sprite lazerColor;
    private int playerIndex;

	void Start ()
    {
        playerIndex = GetComponent<PlayerIdentity> ().playerIndex;
        lazerColor = GetComponent<PlayerIdentity> ().lazerColor;
	}
	
	// Update is called once per frame
	void Update () {
        if (IsFiring()) {
            GameObject lazer = (GameObject)Instantiate (lazerPrefab, spawnPoint.position, spawnPoint.rotation);
            lazer.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = lazerColor;
        }
	}

    bool IsFiring()
    {
        string fireButton = string.Format ("Shoot{0}", playerIndex);
        #if UNITY_STANDALONE_OSX
        if (playerIndex == 1) {
            fireButton = "ShootMac1";
        }
        #endif

        return Input.GetButtonDown (fireButton);
    }
}
