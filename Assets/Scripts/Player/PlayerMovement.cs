using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public int speed = 20;
    public float turnSpeed = 50f;

    private int playerIndex;

    private Animator animator;

    void Start()
    {
        playerIndex = GetComponent<PlayerIdentity> ().playerIndex;

        animator = GetComponent<Animator> ();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis(GetPlayerAxis("Horizontal"));
        float moveVertical = Input.GetAxis(GetPlayerAxis("Vertical"));

        Vector3 mouvment = new Vector3(moveHorizontal, 0, moveVertical);
        animator.SetFloat ("Speed", mouvment.magnitude);
        transform.position = (transform.position + mouvment * speed * Time.deltaTime);

        if (Time.timeScale < 0.95f) {
            return;
        }

        float rotateX = Input.GetAxis(GetPlayerAxis("RotateX"));
        float rotateY = Input.GetAxis(GetPlayerAxis("RotateY"));

        // dead rotation
        if (Mathf.Abs(rotateX) <= 0.1 && Mathf.Abs(rotateY) <= 0.1) {
            return;
        }

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
