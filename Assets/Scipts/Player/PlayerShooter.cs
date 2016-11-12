using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject lazerPrefab;

    private Sprite lazerColor;
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
//            lazer.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = lazerColor;
        }
	}

    bool IsFiring()
    {
       
        #if UNITY_STANDALONE_OSX
        if (playerIndex == 1) {
            fireButton = "ShootMac1";
        }
        #endif
      
        return Input.GetButtonDown (fireButton);
    }
}
