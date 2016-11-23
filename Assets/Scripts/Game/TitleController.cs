using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    public Fader overlay;

	void Update ()
    {
        if (Input.GetButtonDown ("Submit")) {
            overlay.Fade (Color.black, 3.0f, moveToPlayerChoice);
        }

        if (Input.GetKeyDown (KeyCode.Escape)) {
            Application.Quit ();
        }
	}

    void moveToPlayerChoice()
    {
        SceneManager.LoadScene("PlayerValidation");
    }
}
