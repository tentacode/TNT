using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public GameObject AlienBearPrefab, StrangerPrefab, HunterPrefab, ScrapPrefab;
    public Transform Spawn1, Spawn2, Spawn3, Spawn4;
    GameObject AlienBear, Stranger, Hunter, Scrap;
    bool AlienBearDeath = false, StrangerDeath = false, HunterDeath = false, ScrapDeath = false;
    int alivePlayer;
    public int playerActive1, playerActive2, playerActive3, playerActive4;

    public GameObject score;
    public GameObject countdown;

    public bool isGameStarting = true;
    public bool isGameEnd = false;

    bool isPlayer1 = false;
    bool isPlayer2 = false;
    bool isPlayer3 = false;
    bool isPlayer4 = false;

    void Start()
    {
        Cursor.visible = false;
        GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<AudioManager> ().PlayBattleMusic ();

        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02F;

        countdown.SetActive (true);
        score.SetActive (true);
        score.GetComponent<Canvas> ().enabled = false;
        //Set les overlay de la scenne
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);

        isPlayer1 = PlayerPrefs.GetInt ("Player1") != 0;
        isPlayer2 = PlayerPrefs.GetInt ("Player2") != 0;
        isPlayer3 = PlayerPrefs.GetInt ("Player3") != 0;
        isPlayer4 = PlayerPrefs.GetInt ("Player4") != 0;

        // instanciation des joueurs dans la scene
        if (isPlayer1)
        {
            Stranger = Instantiate(StrangerPrefab, Spawn1.position, Quaternion.Euler(new Vector3(0,113.5f,0))) as GameObject;
            Stranger.GetComponent<PlayerIdentity>().playerIndex = PlayerPrefs.GetInt("Player1");
            alivePlayer++;
        }
        if (isPlayer2)
        {
            AlienBear = Instantiate(AlienBearPrefab, Spawn2.position, Quaternion.Euler(new Vector3(0, 45f, 0))) as GameObject;
            AlienBear.GetComponent<PlayerIdentity>().playerIndex = PlayerPrefs.GetInt("Player2");
            alivePlayer++;
        }
        if (isPlayer3)
        {
            Scrap = Instantiate(ScrapPrefab, Spawn3.position, Quaternion.Euler(new Vector3(0, 225f, 0))) as GameObject;
            Scrap.GetComponent<PlayerIdentity>().playerIndex = PlayerPrefs.GetInt("Player3");
            alivePlayer++;
        }
        if (isPlayer4)
        {
            Hunter = Instantiate(HunterPrefab, Spawn4.position, Quaternion.Euler(new Vector3(0, -45, 0))) as GameObject;
            Hunter.GetComponent<PlayerIdentity>().playerIndex = PlayerPrefs.GetInt("Player4");
            alivePlayer++;
        }

        Invoke ("StartGame", 3);
    }

    void StartGame()
    {
        isGameStarting = false;
    }

    void Update()
    {
        if (isGameEnd && Input.GetButtonDown ("Submit")) {
            SceneManager.LoadScene ("Main");
        } else if (isGameEnd && Input.GetButtonDown ("Cancel")) {
            SceneManager.LoadScene ("Title");
        }
    }

    void LateUpdate()
    {
        // Check fin de partie
        if (!isGameEnd && alivePlayer <= 1)
        {
            EndGame ();
        }
    }

    void EndGame()
    {
        isGameEnd = true;
        string winner = "";
        if (!StrangerDeath && isPlayer1)
        {
            winner = "Stranger";
            PlayerPrefs.SetInt("Stranger", PlayerPrefs.GetInt("Stranger") + 1);
        }
        else if (!AlienBearDeath && isPlayer2)
        {
            winner = "Alien Bear";
            PlayerPrefs.SetInt("Alien Bear", PlayerPrefs.GetInt("Alien Bear")+1);
        }
        else if (!ScrapDeath && isPlayer3)
        {
            winner = "Scrap";
            PlayerPrefs.SetInt("Scrap", PlayerPrefs.GetInt("Scrap") + 1);
        }
        else if (!HunterDeath && isPlayer4)
        {
            winner = "Hunter";
            PlayerPrefs.SetInt("Hunter", PlayerPrefs.GetInt("Hunter") + 1);
        }


        GameObject.Find ("WinnerText").GetComponent<Text>().text = winner + " WINS!";
        score.GetComponent<Canvas> ().enabled = true;
        score.GetComponent<ScoreManager> ().Refresh ();
    }
    
    public void DeadPlayerNotifier(string playerName)
    {
        switch (playerName)
        {
           case "Stranger":
                StrangerDeath = true;
                alivePlayer--;
                break;
            case "Alien Bear":
                AlienBearDeath = true;
                alivePlayer--;
                break;
            case "Scrap":
                ScrapDeath = true;
                alivePlayer--;
                break;
            case "Hunter":
                HunterDeath = true;
                alivePlayer--;
                break;
        }
    }
}

    