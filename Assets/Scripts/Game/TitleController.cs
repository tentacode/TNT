using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
	void Update ()
    {
        if (Input.GetButtonDown ("Submit")) {
            SceneManager.LoadScene("PlayerValidation");
        }

        if (Input.GetKeyDown (KeyCode.Escape)) {
            Application.Quit ();
        }
	}
}
