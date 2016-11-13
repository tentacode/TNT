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
    
    void Start()
    {
        //Set les overlay de la scenne
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
        

        //creation des scores
        PlayerPrefs.SetInt("Stranger",0);
        PlayerPrefs.SetInt("Alien Bear",0);
        PlayerPrefs.SetInt("Scrap",0);
        PlayerPrefs.SetInt("Hunter",0);

        // instanciation des joueurs dans la scene
        if (PlayerPrefs.GetInt("Player1") != 0)
        {
            Stranger = Instantiate(StrangerPrefab, Spawn1.position, Quaternion.Euler(new Vector3(0,Spawn1.rotation.y,0))) as GameObject;
            Stranger.GetComponent<PlayerIdentity>().playerIndex = PlayerPrefs.GetInt("Player1");
            alivePlayer++;
        }
        if (PlayerPrefs.GetInt("Player2") != 0)
        {
            AlienBear = Instantiate(StrangerPrefab, Spawn2.position, Quaternion.Euler(new Vector3(0, Spawn2.rotation.y, 0))) as GameObject;
            AlienBear.GetComponent<PlayerIdentity>().playerIndex = PlayerPrefs.GetInt("Player2");
            alivePlayer++;
        }
        if (PlayerPrefs.GetInt("Player3") != 0)
        {
            Scrap = Instantiate(StrangerPrefab, Spawn3.position, Quaternion.Euler(new Vector3(0, Spawn3.rotation.y, 0))) as GameObject;
            Scrap.GetComponent<PlayerIdentity>().playerIndex = PlayerPrefs.GetInt("Player3");
            alivePlayer++;
        }
        if (PlayerPrefs.GetInt("Player4") != 0)
        {
            Hunter = Instantiate(StrangerPrefab, Spawn4.position, Quaternion.Euler(new Vector3(0, Spawn4.rotation.y, 0))) as GameObject;
            Hunter.GetComponent<PlayerIdentity>().playerIndex = PlayerPrefs.GetInt("Player4");
            alivePlayer++;
        }
    }

    void LateUpdate()
    {
        // Check fin de partie
        if (alivePlayer <= 1)
        {
            if (!AlienBearDeath)
            {
                PlayerPrefs.SetInt("Alien Bear", PlayerPrefs.GetInt("Alien Bear")+1);
            }
            if (!StrangerDeath)
            {
                PlayerPrefs.SetInt("Alien Bear", PlayerPrefs.GetInt("Alien Bear") + 1);
            }
            if (!HunterDeath)
            {
                PlayerPrefs.SetInt("Alien Bear", PlayerPrefs.GetInt("Alien Bear") + 1);
            }
            if (!ScrapDeath)
            {
                PlayerPrefs.SetInt("Alien Bear", PlayerPrefs.GetInt("Alien Bear") + 1);
            }
            //applique l'overlay des scores
            SceneManager.LoadScene("Score", LoadSceneMode.Additive);
        }
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

    