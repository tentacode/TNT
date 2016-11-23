using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ValidationController : MonoBehaviour {

    public GameObject image1,image2,image3,image4,text1,press1,press2,press3,press4;
    int countPlayer;
    bool playerReady1, playerReady2, playerReady3, playerReady4, start;
    bool gamepadReady1, gamepadReady2, gamepadReady3, gamepadReady4;

	void Start ()
    {
        // text "Ready" par player
        image1.SetActive(false);
        image2.SetActive(false);
        image3.SetActive(false);
        image4.SetActive(false);

        // texte "Press start" pour commencer
        text1.SetActive(false);

        // images des boutons XBOX
        press1.SetActive(true);
        press2.SetActive(true);
        press3.SetActive(true);
        press4.SetActive(true);

        countPlayer = 0;
        playerReady1 = false;
        playerReady2 = false;
        playerReady3 = false;
        playerReady4 = false;
        start = false;

        PlayerPrefs.SetInt ("Player1", 0);
        PlayerPrefs.SetInt ("Player2", 0);
        PlayerPrefs.SetInt ("Player3", 0);
        PlayerPrefs.SetInt ("Player4", 0);

        PlayerPrefs.SetInt ("Stranger", 0);
        PlayerPrefs.SetInt ("Alien Bear", 0);
        PlayerPrefs.SetInt ("Scrap", 0);
        PlayerPrefs.SetInt ("Hunter", 0);
    }

	// Update is called once per frame
	void Update ()
    {
        CheckPlayer1();
        CheckPlayer2();
        CheckPlayer3();
        CheckPlayer4();

        if (countPlayer>=2)
        {
            text1.SetActive(true);
            start = true;
        }

        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("Title");
        }

        if (start && Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene("Main");
        }
    }

    int GetPlayerIndexButton(int buttonIndex)
    {
        #if UNITY_STANDALONE_OSX
        buttonIndex += 16;
        #endif

        int playerIndex = 0;
        if (!gamepadReady1 && Input.GetKeyDown (string.Format("joystick 1 button {0}", buttonIndex))) {
            playerIndex = 1;
            gamepadReady1 = true;
        } else if (!gamepadReady2 && Input.GetKeyDown (string.Format("joystick 2 button {0}", buttonIndex))) {
            playerIndex = 2;
            gamepadReady2 = true;
        } else if (!gamepadReady3 && Input.GetKeyDown (string.Format("joystick 3 button {0}", buttonIndex))) {
            playerIndex = 3;
            gamepadReady3 = true;
        } else if (!gamepadReady4 && Input.GetKeyDown (string.Format("joystick 4 button {0}", buttonIndex))) {
            playerIndex = 4;
            gamepadReady4 = true;
        }

        return playerIndex;
    }

    void CheckPlayer1()
    {
        if (playerReady1) {
            return;
        }

        int playerIndex = GetPlayerIndexButton(2);
        if (playerIndex == 0) {
            return;
        }

        press3.SetActive (false);
        image3.SetActive (true);

        countPlayer += 1;
        playerReady1 = true;

        PlayerPrefs.SetInt ("Player1", playerIndex);
    }

    void CheckPlayer2()
    {
        if (playerReady2) {
            return;
        }

        int playerIndex = GetPlayerIndexButton(0);
        if (playerIndex == 0) {
            return;
        }

        press1.SetActive (false);
        image1.SetActive (true);

        countPlayer += 1;
        playerReady2 = true;

        PlayerPrefs.SetInt ("Player2", playerIndex);
    }

    void CheckPlayer3()
    {
        if (playerReady3) {
            return;
        }

        int playerIndex = GetPlayerIndexButton(3);
        if (playerIndex == 0) {
            return;
        }

        press4.SetActive (false);
        image4.SetActive (true);

        countPlayer += 1;
        playerReady3 = true;

        PlayerPrefs.SetInt ("Player3", playerIndex);
    }

    void CheckPlayer4()
    {
        if (playerReady4) {
            return;
        }

        int playerIndex = GetPlayerIndexButton(1);
        if (playerIndex == 0) {
            return;
        }

        press2.SetActive (false);
        image2.SetActive (true);

        countPlayer += 1;
        playerReady4 = true;

        PlayerPrefs.SetInt ("Player4", playerIndex);
    }
}
