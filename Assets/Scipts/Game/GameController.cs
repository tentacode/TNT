using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    enum gameState {INTRODUCTION,VALIDPLAYERS,INTROGAME,GAME,ENDGAME}
    gameState currentState;
    gameState previousState;
	void Awake ()
    {
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
	}
}
