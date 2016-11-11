using UnityEngine;
using System.Collections;

public class LazerBehavior : MonoBehaviour {

    public float lazerSpeed;
    private Rigidbody rgbd;

    // Use this for initialization
    void Start () {
        rgbd = gameObject.GetComponent<Rigidbody>();
        rgbd.AddForce(new Vector3(1, 1, 0) * lazerSpeed, ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void Update () {
        float angle = Mathf.Atan2(rgbd.velocity.x, rgbd.velocity.y) * Mathf.Rad2Deg;
        transform.GetChild(0).transform.rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
        Debug.Log("angle : " + angle);
        Debug.Log("x : " + transform.GetChild(0).transform.rotation.x );
        Debug.Log("y : " + transform.GetChild(0).transform.rotation.y );
        Debug.Log("z : " + transform.GetChild(0).transform.rotation.z );
    }
}
