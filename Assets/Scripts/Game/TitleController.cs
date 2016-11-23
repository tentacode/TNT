using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    public Fader overlay;

    void Nil ()
    {
    }

    void Start()
    {
        overlay.Fade (new Color(0,0,0,0), 5.0f, Nil);
    }

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
