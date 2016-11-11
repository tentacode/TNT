using UnityEngine;
using System.Collections;

public class TestBullet : MonoBehaviour {


   
    public GameObject bullet;
   

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
    }
}
