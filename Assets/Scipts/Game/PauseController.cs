using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour
{
    public GameObject pauseCanvas;
    private bool isPaused = false;

	void Start ()
    {
        pauseCanvas.SetActive (false);    
	}
	
	void Update ()
    {
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
