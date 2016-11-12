using UnityEngine;
using System.Collections;

public class LazerBehavior : MonoBehaviour {

    public float lazerSpeed;
    public int maxBounces;

    private Rigidbody rgbd;
    private int bounceCounter;
    private bool hasCollided = false;
    private bool isExpanding = true;
    public int playerIndex;
    private Vector3 expandedScale;
    private Vector3 initialScale;


    // Use this for initialization
    void Start()
    {
        initialScale = new Vector3 (1.0f, 1.0f, 0.1f);
        expandedScale = new Vector3 (1.0f, 1.0f, 1.0f);
        rgbd = GetComponent<Rigidbody> ();
        rgbd.AddForce (transform.forward * lazerSpeed, ForceMode.Impulse); 

        bounceCounter = 0;
        maxBounces = 9;
    }

    // Update is called once per frame
    void Update()
    {
        var child = transform.GetChild (0);
        if (isExpanding) {
            child.transform.localScale = Vector3.Lerp (
                transform.localScale, 
                expandedScale, 50 * Time.deltaTime
            );

            if (child.transform.localScale == expandedScale) {
                isExpanding = false;
            }
        }

        if (hasCollided) {
            child.transform.localScale = initialScale;
            isExpanding = true;
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
        bounceCounter++;
        hasCollided = true;
    }
}
