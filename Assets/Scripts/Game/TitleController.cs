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
            AudioManager am = GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<AudioManager> ();
            am.PlayClip (am.reload, Vector3.zero, 1.0f);

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
