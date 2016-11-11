using UnityEngine;
using System.Collections;

public class LazerBehavior : MonoBehaviour {

    private Rigidbody rgbd;

    // Use this for initialization
    void Start () {
        rgbd = gameObject.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        float angle = Mathf.Atan2(rgbd.velocity.x, rgbd.velocity.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
