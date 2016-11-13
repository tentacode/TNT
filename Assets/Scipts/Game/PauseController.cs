using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour
{
    public GameObject pauseCanvas;
    private bool isPaused = false;
    private bool canPause = false;

	void Start ()
    {
        pauseCanvas.SetActive (false);
        Invoke ("PauseActive", 2.0f);
	}

    void PauseActive()
    {
        canPause = true;
    }
	
	void Update ()
    {
        if (!canPause) {
            return;
        }

        GameObject gameController = GameObject.Find("GameController");
        if (gameController.GetComponent<GameController> ().isGameEnd) {
            return;
        }

        if (isPaused && Input.GetButtonDown("Cancel")) {
            Time.timeScale = 1;
            Application.LoadLevel (0); 
        }

        if (Input.GetButtonDown("Submit")) {
            TogglePause ();
        }
	}

    void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused) {
            pauseCanvas.SetActive(true);
            Time.timeScale = 0;
        } else {
            pauseCanvas.SetActive(false);
            Time.timeScale = 1;
        }

    }
}
