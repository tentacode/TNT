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
        audioManager.PlayClip (audioManager.fireLazer, transform.position);
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
