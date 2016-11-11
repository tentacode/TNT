using UnityEngine;
using System.Collections;

public class LazerBehavior : MonoBehaviour {

    public float lazerSpeed;
    public int maxBounces;

    private Rigidbody rgbd;
    private int bounceCounter;

    // Use this for initialization
    void Start()
    {
        rgbd = gameObject.GetComponent<Rigidbody>();
        rgbd.AddForce(new Vector3(1, 1, 0) * lazerSpeed, ForceMode.Impulse);
        bounceCounter = 0;
        maxBounces = 9;
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(rgbd.velocity.x, rgbd.velocity.y) * Mathf.Rad2Deg;
        transform.GetChild(0).transform.rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
        Debug.Log("angle : " + angle);
        Debug.Log("x : " + transform.GetChild(0).transform.rotation.x);
        Debug.Log("y : " + transform.GetChild(0).transform.rotation.y);
        Debug.Log("z : " + transform.GetChild(0).transform.rotation.z);
        if (bounceCounter > maxBounces)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        bounceCounter++;
    }
}
