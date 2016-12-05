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
    private GameController gameController;

    void Nil()
    {
    }

	void Start ()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        pauseCanvas.SetActive (false);
        Invoke ("PauseActive", 3.5f);
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

        if (gameController.isGameEnd && !isPaused) {
            return;
        }

        if (gameController.isGameEnd && isPaused) {
            ResumeTime ();
            pauseCanvas.SetActive (false);
        }

        if (isPaused && Input.GetButtonDown("Cancel")) {
            ResumeTime ();

            SceneManager.LoadScene ("Title");
        }

        if (IsPauseButton()) {
            TogglePause ();
        }
	}

    void ResumeTime()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02F;
        audioManager.musicSource.pitch = 1;
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
                isDepausing = false;
                ResumeTime ();
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
            DeactivatePause ();
            Time.timeScale = 0.1f;
            overlay.Fade(new Color(0,0,0,0f), 7, Nil);
            isPausing = false;
            isDepausing = true;
            pauseCanvas.SetActive (false);
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
