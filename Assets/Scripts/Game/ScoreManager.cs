using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Score : IComparable<Score>
{
    public string name;
    public int score;

    public Score(string _name, int _score)
    {
        name = _name;
        score = _score;
    }

    public int CompareTo(Score s)
    {
        return s.score.CompareTo(score);
    }
}

public class ScoreManager : MonoBehaviour {

    public Text scoreText;

    public void Refresh() {

        List<Score> scores =  new List<Score>();

        if (PlayerPrefs.GetInt("Player2") != 0) {
            scores.Add (new Score("Alien Bear", PlayerPrefs.GetInt ("Alien Bear")));
        }
        if (PlayerPrefs.GetInt("Player4") != 0) {
            scores.Add (new Score("Hunter", PlayerPrefs.GetInt ("Hunter")));
        }
        if (PlayerPrefs.GetInt("Player3") != 0) {
            scores.Add (new Score("Scrap", PlayerPrefs.GetInt ("Scrap")));
        }
        if (PlayerPrefs.GetInt("Player1") != 0) {
            scores.Add (new Score("Stranger", PlayerPrefs.GetInt ("Stranger")));
        }

        scores.Sort ();

        string textScores = "";
        foreach( Score score in scores)
        {
            textScores += score.name + " " + score.score + "\n";
        }

        scoreText.text = textScores;
    }
}
