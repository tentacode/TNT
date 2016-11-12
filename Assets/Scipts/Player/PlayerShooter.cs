using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject lazerPrefab;

    private Texture lazerColor;
    private int playerIndex;
    string fireButton;
    void Start ()
    {
        playerIndex = GetComponent<PlayerIdentity> ().playerIndex;
        lazerColor = GetComponent<PlayerIdentity> ().lazerColor;
        fireButton = string.Format("Shoot{0}", playerIndex);
    }
	
	// Update is called once per frame
	void Update () {
        if (IsFiring()) {
            GameObject lazer = (GameObject)Instantiate (lazerPrefab, spawnPoint.position, spawnPoint.rotation);
            lazer.transform.GetChild(0).GetComponent<Renderer>().material.mainTexture = lazerColor;
        }
	}

    bool IsFiring()
    {
       
        #if UNITY_STANDALONE_OSX
        if (playerIndex <= 2) {
            fireButton = string.Format("ShootMac{0}", playerIndex);
        }
        #endif
      
        return Input.GetButtonDown (fireButton);
    }
}
