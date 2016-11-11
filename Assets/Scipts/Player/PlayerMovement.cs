using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public int speed = 10;
    public float turnSpeed = 50f;

    // Update is called once per frame
    /*void Update () {
	
       
	}*/
   new Rigidbody rigidbody;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float rotateX = Input.GetAxis("RotateX");
        float rotateY = Input.GetAxis("RotateY");

        Vector3 mouvment = new Vector3(moveHorizontal, moveVertical, 0);
        rigidbody.MovePosition(transform.position + mouvment * speed * Time.deltaTime);


        ///////////////// rotate player for shoot  //////////////
     /*   if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);*/
        ////////////////////////////////////////////////////////


        float angle = Mathf.Atan2(rotateX, rotateY) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
    }
}
