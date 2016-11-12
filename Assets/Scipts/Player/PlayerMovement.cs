using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public int speed = 10;
    public float turnSpeed = 50f;

    private int playerIndex;
    private Rigidbody rigidbody;

    private Animator animator;

    void Start()
    {
        playerIndex = GetComponent<PlayerIdentity> ().playerIndex;
        rigidbody = gameObject.GetComponent<Rigidbody>();

        animator = GetComponent<Animator> ();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis(GetPlayerAxis("Horizontal"));
        float moveVertical = Input.GetAxis(GetPlayerAxis("Vertical"));
        float rotateX = Input.GetAxis(GetPlayerAxis("RotateX"));
        float rotateY = Input.GetAxis(GetPlayerAxis("RotateY"));

        Vector3 mouvment = new Vector3(moveHorizontal, 0, moveVertical);
        animator.SetFloat ("Speed", mouvment.magnitude);
        rigidbody.MovePosition(transform.position + mouvment * speed * Time.deltaTime);

        float angle = Mathf.Atan2(rotateX, rotateY) * Mathf.Rad2Deg + 90.0f;
        transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
    }

    string GetPlayerAxis(string axis)
    {
        #if UNITY_STANDALONE_OSX
        if (playerIndex <= 2 && axis == "RotateX") {
            axis = "RotateXMac";
        }
        if (playerIndex <= 2 && axis == "RotateY") {
            axis = "RotateYMac";
        }
        #endif

        return string.Format ("{0}{1}", axis, playerIndex);
    }
}
