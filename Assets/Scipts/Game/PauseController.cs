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
        if (Input.GetKeyDown(KeyCode.Escape)) {
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
