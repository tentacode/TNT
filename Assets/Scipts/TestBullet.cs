using UnityEngine;
using System.Collections;

public class TestBullet : MonoBehaviour {


   
    public GameObject bullet;
    public float lazerSpeed;

    // Use this for initialization
    void Start () {
     
       
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        
    }

    // instencie et applique une force a l'objet 
    void Shoot()
    {
      
        GameObject lazer=  Instantiate(bullet);
        lazer.GetComponent<Rigidbody>().AddForce(new Vector3(1f,5f,0)*lazerSpeed,ForceMode.Impulse);
    }
}
