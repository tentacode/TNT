using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject lazerPrefab;
    public AudioManager audioManager;

    private Texture lazerColor;
    private Color particleColor;
    private int playerIndex;
    string fireButton;

    private float RELOAD_TIME = 1.7f;
    private int bullets = 6;

    void Start ()
    {
        playerIndex = GetComponent<PlayerIdentity> ().playerIndex;
        lazerColor = GetComponent<PlayerIdentity> ().lazerColor;
        particleColor = GetComponent<PlayerIdentity> ().color;
        fireButton = string.Format("Shoot{0}", playerIndex);
    }
	
	// Update is called once per frame
	void Update () {
        if (IsFiring()) {
            if (bullets > 0) {
                Fire ();
            }
        }
	}

    void Fire()
    {
        GameObject lazer = (GameObject)Instantiate (lazerPrefab, spawnPoint.position, spawnPoint.rotation);
        lazer.transform.GetChild(0).GetComponent<Renderer>().material.mainTexture = lazerColor;
        lazer.transform.GetChild(0).GetChild(0).GetComponent<ParticleSystem>().startColor = particleColor;
        lazer.GetComponent<LazerBehavior>().playerIndex = playerIndex;

        bullets--;
        if (bullets == 0) {
            Invoke("Reload", 0.2f);
        }
    }

    void Reload ()
    {
        audioManager.PlayClip (audioManager.reload, transform.position);

        Invoke("Recharge", RELOAD_TIME);
    }

    void Recharge ()
    {
        bullets = 6;
    }

    bool IsFiring()
    {      
        return Input.GetButtonDown (fireButton);
    }
}
