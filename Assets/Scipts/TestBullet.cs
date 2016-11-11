using UnityEngine;
using System.Collections;

public class TestBullet : MonoBehaviour {


    private Rigidbody rgbd;
    private GameObject bullet;

    // Use this for initialization
    void Start () {
        rgbd = gameObject.GetComponent<Rigidbody>();
        bullet = GameObject.Find("lazer");
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(1))
        {
            Instantiate(bullet);
        }

    }
}
