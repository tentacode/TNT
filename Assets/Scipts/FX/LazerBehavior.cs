using UnityEngine;
using System.Collections;

public class LazerBehavior : MonoBehaviour {

    public float lazerSpeed;
    public int maxBounces;

    private Rigidbody rgbd;
    private int bounceCounter;
    private bool hasCollided = false;

    // Use this for initialization
    void Start()
    {
        rgbd = GetComponent<Rigidbody> ();
        rgbd.AddForce (transform.forward * lazerSpeed, ForceMode.Impulse); 

        bounceCounter = 0;
        maxBounces = 9;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasCollided) {
            float angle = Mathf.Atan2 (rgbd.velocity.x, rgbd.velocity.z) * Mathf.Rad2Deg;
            transform.GetChild (0).transform.rotation = Quaternion.AngleAxis (angle, Vector3.up);
            hasCollided = false;
        }

        if (bounceCounter > maxBounces)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        bounceCounter++;
        hasCollided = true;
    }
}
