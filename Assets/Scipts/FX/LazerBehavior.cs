using UnityEngine;
using System.Collections;

public class LazerBehavior : MonoBehaviour {

    public float lazerSpeed;
    public int maxBounces;

    private Rigidbody rgbd;
    private int bounceCounter;
    private bool hasCollided = false;
    public int playerIndex;

    public AudioManager audioManager;

    // Use this for initialization
    void Start()
    {
        AudioClip clip = audioManager.fireLazer1;
        switch (playerIndex) {
        case 1:
            clip = audioManager.fireLazer1;
            break;
        case 2:
            clip = audioManager.fireLazer2;
            break;
        case 3:
            clip = audioManager.fireLazer3;
            break;
        case 4:
            clip = audioManager.fireLazer4;
            break;
        default:
            Debug.LogError("No player index");
            break;
        }

        audioManager.PlayClip (clip, transform.position);
        rgbd = GetComponent<Rigidbody> ();
        rgbd.AddForce (transform.forward * lazerSpeed, ForceMode.Impulse); 

        bounceCounter = 0;
        maxBounces = 9;
    }

    // Update is called once per frame
    void Update()
    {
        var child = transform.GetChild (0);
       
        if (hasCollided) {
            float angle = Mathf.Atan2 (rgbd.velocity.x, rgbd.velocity.z) * Mathf.Rad2Deg;
            child.transform.rotation = Quaternion.AngleAxis (angle, Vector3.up);
            hasCollided = false;
        }

        if (bounceCounter > maxBounces)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Wall") {
            audioManager.PlayClip (audioManager.bounceWall, collision.collider.transform.position, 0.3f);
        } else if (collision.collider.tag == "Shield") {
            audioManager.PlayClip (audioManager.bounceShield, collision.collider.transform.position);
        }

        bounceCounter++;
        hasCollided = true;
    }
}
