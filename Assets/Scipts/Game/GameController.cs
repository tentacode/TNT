﻿using UnityEngine;
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


    public bool isGameEnd = false;

    void Start()
    {
        //Set les overlay de la scenne
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
        //applique l'overlay des scores
        SceneManager.LoadScene("Score", LoadSceneMode.Additive);

        // instanciation des joueurs dans la scene
        if (PlayerPrefs.GetInt("Player1") != 0)
        {
            Stranger = Instantiate(StrangerPrefab, Spawn1.position, Quaternion.Euler(new Vector3(0,Spawn1.rotation.y,0))) as GameObject;
            Stranger.GetComponent<PlayerIdentity>().playerIndex = PlayerPrefs.GetInt("Player1");
            alivePlayer++;
        }
        if (PlayerPrefs.GetInt("Player2") != 0)
        {
            AlienBear = Instantiate(AlienBearPrefab, Spawn2.position, Quaternion.Euler(new Vector3(0, Spawn2.rotation.y, 0))) as GameObject;
            AlienBear.GetComponent<PlayerIdentity>().playerIndex = PlayerPrefs.GetInt("Player2");
            alivePlayer++;
        }
        if (PlayerPrefs.GetInt("Player3") != 0)
        {
            Scrap = Instantiate(ScrapPrefab, Spawn3.position, Quaternion.Euler(new Vector3(0, Spawn3.rotation.y, 0))) as GameObject;
            Scrap.GetComponent<PlayerIdentity>().playerIndex = PlayerPrefs.GetInt("Player3");
            alivePlayer++;
        }
        if (PlayerPrefs.GetInt("Player4") != 0)
        {
            Hunter = Instantiate(HunterPrefab, Spawn4.position, Quaternion.Euler(new Vector3(0, Spawn4.rotation.y, 0))) as GameObject;
            Hunter.GetComponent<PlayerIdentity>().playerIndex = PlayerPrefs.GetInt("Player4");
            alivePlayer++;
        }
    }

    void Update()
    {
        if (isGameEnd && Input.GetButtonDown ("Submit")) {
            SceneManager.LoadScene ("Main");
        } else if (isGameEnd && Input.GetButtonDown ("Cancel")) {
            Application.LoadLevel (0); 
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

        Debug.Log("Stranger" + PlayerPrefs.GetInt("Stranger"));
        Debug.Log("Alien Bear" + PlayerPrefs.GetInt("Alien Bear"));
        Debug.Log("Scrap" + PlayerPrefs.GetInt("Scrap"));
        Debug.Log("Hunter" + PlayerPrefs.GetInt("Hunter"));
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

    