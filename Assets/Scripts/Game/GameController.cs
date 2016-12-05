using UnityEngine;
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

    void Start()
    {
        Cursor.visible = false;
        GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<AudioManager> ().PlayBattleMusic ();

        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02F;

        countdown.SetActive (true);
        score.SetActive (false);
        //Set les overlay de la scenne
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);

        // instanciation des joueurs dans la scene
        if (PlayerPrefs.GetInt("Player1") != 0)
        {
            Stranger = Instantiate(StrangerPrefab, Spawn1.position, Quaternion.Euler(new Vector3(0,113.5f,0))) as GameObject;
            Stranger.GetComponent<PlayerIdentity>().playerIndex = PlayerPrefs.GetInt("Player1");
            alivePlayer++;
        }
        if (PlayerPrefs.GetInt("Player2") != 0)
        {
            AlienBear = Instantiate(AlienBearPrefab, Spawn2.position, Quaternion.Euler(new Vector3(0, 45f, 0))) as GameObject;
            AlienBear.GetComponent<PlayerIdentity>().playerIndex = PlayerPrefs.GetInt("Player2");
            alivePlayer++;
        }
        if (PlayerPrefs.GetInt("Player3") != 0)
        {
            Scrap = Instantiate(ScrapPrefab, Spawn3.position, Quaternion.Euler(new Vector3(0, 225f, 0))) as GameObject;
            Scrap.GetComponent<PlayerIdentity>().playerIndex = PlayerPrefs.GetInt("Player3");
            alivePlayer++;
        }
        if (PlayerPrefs.GetInt("Player4") != 0)
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
        if (!StrangerDeath && PlayerPrefs.GetInt("Player1") != 0)
        {
            PlayerPrefs.SetInt("Stranger", PlayerPrefs.GetInt("Stranger") + 1);
        }
        if (!AlienBearDeath && PlayerPrefs.GetInt("Player2") != 0)
        {
            PlayerPrefs.SetInt("Alien Bear", PlayerPrefs.GetInt("Alien Bear")+1);
        }
        if (!ScrapDeath && PlayerPrefs.GetInt("Player3") != 0)
        {
            PlayerPrefs.SetInt("Scrap", PlayerPrefs.GetInt("Scrap") + 1);
        }
        if (!HunterDeath && PlayerPrefs.GetInt("Player4") != 0)
        {
            PlayerPrefs.SetInt("Hunter", PlayerPrefs.GetInt("Hunter") + 1);
        }

        score.SetActive (true);
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

    