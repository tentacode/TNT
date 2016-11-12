using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    enum gameState {INTRODUCTION,VALIDPLAYERS,INTROGAME,GAME,ENDGAME}
    gameState currentState;
    gameState previousState;
    List<Score> playerSocres = new List<Score>();
    public GameObject player1Prefab,player2Prefab,player3Prefab,player4Prefab;
    GameObject player1, player2, player3, player4;
    bool playerSelected1 = false, playerSelected2 = false, playerSelected3 = false, playerSelected4 = false;

    public Transform spawn1, spawn2, spawn3, spawn4;
    int countPlayer,countPlayersAlive;
    //GameObject gameObject;
    void Awake ()
    {
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
      //  SceneManager.LoadScene("PlayerValidation", LoadSceneMode.Additive);
        DontDestroyOnLoad(gameObject);
        countPlayer = 0;
        countPlayersAlive = 0;
    }
    
    void Update()
    {
       
    }

    void StateManager()
    {
        switch (currentState)
        {
            case gameState.INTRODUCTION:
                if (Input.GetButtonDown("Start1")|| Input.GetButtonDown("Start2")
                    || Input.GetButtonDown("Start3")|| Input.GetButtonDown("Start4"))
                {
                    ChangeCurrentState(gameState.VALIDPLAYERS);
                   
                }
                
                break;
            case gameState.VALIDPLAYERS:
                

                if (Input.GetButtonDown("Shoot1")&& !playerSelected1)
                {
                    playerSocres.Add(new Score(1));
                    countPlayer++;
                }
                if (Input.GetButtonDown("Shoot2") && !playerSelected2)
                {
                    playerSocres.Add(new Score(2));
                    countPlayer++;
                }
                if (Input.GetButtonDown("Shoot3") && !playerSelected3)
                {
                    playerSocres.Add(new Score(3));
                    countPlayer++;
                }
                if (Input.GetButtonDown("Shoot4") && !playerSelected4)
                {
                    playerSocres.Add(new Score(4));
                    countPlayer++;
                }
                if ((Input.GetButtonDown("Start1") || Input.GetButtonDown("Start2")
                  || Input.GetButtonDown("Start3") || Input.GetButtonDown("Start4")) && countPlayer>= 2)
                {
                    ChangeCurrentState(gameState.INTROGAME);

                }
                
                break;
            case gameState.INTROGAME:

                if (countPlayer >= 2)
                {
                    foreach (Score score in playerSocres)
                    {
                        switch (score.playerName.ToString())
                        {
                            case "1":
                                player1 = Instantiate(player1Prefab, spawn1.position, Quaternion.Euler(new Vector3(1, 0, 1))) as GameObject;
                                break;
                            case "2":
                                player2 = Instantiate(player2Prefab, spawn2.position, Quaternion.Euler(new Vector3(1, 0, -1))) as GameObject;
                                break;
                            case "3":
                                player3 = Instantiate(player3Prefab, spawn3.position, Quaternion.Euler(new Vector3(-1, 0, -1))) as GameObject;
                                break;
                            case "4":
                                player4 = Instantiate(player4Prefab, spawn4.position, Quaternion.Euler(new Vector3(-1, 0, 1))) as GameObject;
                                break;
                        }
                    }
                    ChangeCurrentState(gameState.GAME); // pour passer au game
                    countPlayersAlive = countPlayer;
                }

                break;
            case gameState.GAME:
                if (countPlayersAlive<=1)
                {
                    ChangeCurrentState(gameState.ENDGAME);
                }
                break;
            case gameState.ENDGAME:
                
                break;
            default:
                break;
        }
    }

    void ChangeCurrentState(gameState myState)
    {
        previousState = currentState;
        currentState = myState;
    }
    public void PlayerDeath(int playerIndex)
        {
       
            countPlayersAlive--;
        }
    public void ResetGame()
        {
            countPlayer = 0;
            countPlayersAlive = 0;
            currentState = gameState.INTRODUCTION;
            playerSocres.Clear();
    }

    public void Reload()
    {
        countPlayersAlive = countPlayer;
        currentState = gameState.GAME;
    }


    public class Score
    {
        public string playerName { get; set; }
        public int playerScore { get; set; }


        public Score(int playerIndex)
        {
            playerName = string.Format("Player{0}", playerIndex);

        }


    }
}
