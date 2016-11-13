using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;

    public void Refresh() {
        scoreText.text = "";
        if (PlayerPrefs.GetInt("Player1") != 0) {
            scoreText.text += "Stranger "  + PlayerPrefs.GetInt("Stranger") + "\n";
        }
        if (PlayerPrefs.GetInt("Player2") != 0) {
            scoreText.text += "Alien Bear "  + PlayerPrefs.GetInt("Alien Bear") + "\n";
        }
        if (PlayerPrefs.GetInt("Player3") != 0) {
            scoreText.text += "Scrap "  + PlayerPrefs.GetInt("Scrap") + "\n";
        }
        if (PlayerPrefs.GetInt("Player4") != 0) {
            scoreText.text += "Hunter "  + PlayerPrefs.GetInt("Hunter") + "\n";
        }
    }
}
