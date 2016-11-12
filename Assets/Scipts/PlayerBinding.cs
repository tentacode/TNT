using UnityEngine;
using System.Collections;

public class PlayerBinding : MonoBehaviour {

	
	void LateUpdate () {
	
        if (transform.position.x <= -50)
        {
            transform.position = new Vector3(-50, transform.position.y, transform.position.z) ;
        }
        if (transform.position.z <= -20)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,-20);
        }
        if (transform.position.z >= 20)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 20);
        }
        if (transform.position.x >= 43)
        {
            transform.position = new Vector3(43, transform.position.y, transform.position.z);
        }
    }
}
