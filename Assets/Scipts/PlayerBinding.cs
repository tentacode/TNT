using UnityEngine;
using System.Collections;

public class PlayerBinding : MonoBehaviour {
    public int xBoundary = 40;
    public int zBoundary = 20;
	
	void LateUpdate () {
	
        if (transform.position.x <= -xBoundary)
        {
            transform.position = new Vector3(-xBoundary, transform.position.y, transform.position.z) ;
        }
        if (transform.position.z <= -zBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,-zBoundary);
        }
        if (transform.position.z >= zBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundary);
        }
        if (transform.position.x >= xBoundary)
        {
            transform.position = new Vector3(xBoundary, transform.position.y, transform.position.z);
        }
    }
}
