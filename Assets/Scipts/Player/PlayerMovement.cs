using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public int speed = 10;
    public float turnSpeed = 50f;

    private int playerIndex;
    private Rigidbody rigidbody;

    void Start()
    {
        playerIndex = GetComponent<PlayerIdentity> ().playerIndex;
        Debug.Log(playerIndex);
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis(GetPlayerAxis("Horizontal"));
        float moveVertical = Input.GetAxis(GetPlayerAxis("Vertical"));
        float rotateX = Input.GetAxis(GetPlayerAxis("RotateX"));
        float rotateY = Input.GetAxis(GetPlayerAxis("RotateY"));

        Vector3 mouvment = new Vector3(moveHorizontal, moveVertical, 0);
        rigidbody.MovePosition(transform.position + mouvment * speed * Time.deltaTime);

        float angle = Mathf.Atan2(rotateX, rotateY) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
    }

    string GetPlayerAxis(string axis)
    {
        //#if UNITY_STANDALONE_OSX
        //if (playerIndex == 1 && axis == "RotateX") {
        //    axis = "RotateXMac";
        //}
        //if (playerIndex == 1 && axis == "RotateY") {
        //    axis = "RotateYMac";
        //}
        //#endif

        return string.Format ("{0}{1}", axis, playerIndex);
    }
}
