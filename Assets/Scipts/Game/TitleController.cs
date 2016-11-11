using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
	void Update ()
    {
        if (Input.GetKeyDown (KeyCode.Space)) {
            SceneManager.LoadScene("Main");
        }

        if (Input.GetKeyDown (KeyCode.Escape)) {
            Application.Quit ();
        }
	}
}
