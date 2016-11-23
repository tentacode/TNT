using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject pauseCanvas;
    private bool isPaused = false;
    private bool isPausing = false;
    private bool isDepausing = false;
    private bool canPause = false;
    public Fader overlay;
    private AudioManager audioManager;

    void Nil()
    {
    }

	void Start ()
    {
        Debug.Log (Time.fixedDeltaTime);
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
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
            Time.fixedDeltaTime = 0.02F;
            SceneManager.LoadScene ("Title");
        }

        if (IsPauseButton()) {
            TogglePause ();
        }
	}

    bool IsPauseButton()
    {
        #if UNITY_STANDALONE_OSX
            return Input.GetKeyDown ("joystick button 9");
        #endif
        return Input.GetKeyDown ("joystick button 7");
    }

    void FixedUpdate()
    {
        if (isPausing) {
            audioManager.musicSource.pitch = Mathf.Lerp(audioManager.musicSource.pitch, 0.5f, 0.05f);
            Time.timeScale = Mathf.Lerp (Time.timeScale, 0, 0.07f);
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            if (Time.timeScale < 0.001f) {
                Time.timeScale = 0;
                isPausing = false;
                Time.fixedDeltaTime = 0.02F;
            }
        }

        if (isDepausing) {
            audioManager.musicSource.pitch = Mathf.Lerp(audioManager.musicSource.pitch, 1f, 0.2f);
            Time.timeScale = Mathf.Lerp (Time.timeScale, 1, 0.2f);
            Time.fixedDeltaTime = 0.02F * Time.timeScale;

            if (Time.timeScale > 0.99f) {
                Time.timeScale = 1;
                isDepausing = false;
                Time.fixedDeltaTime = 0.02F;
            }
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused) {
            ActivatePause ();
            overlay.Fade(new Color(0,0,0,0.5f), 7, Nil);
            isDepausing = false;
            isPausing = true;
        } else {
            Time.timeScale = 0.1f;
            overlay.Fade(new Color(0,0,0,0f), 7, DeactivatePause);
            isPausing = false;
            isDepausing = true;
        }

    }

    void ActivatePause()
    {
        pauseCanvas.SetActive(true);
    }

    void DeactivatePause()
    {
        pauseCanvas.SetActive(false);
    }
}
