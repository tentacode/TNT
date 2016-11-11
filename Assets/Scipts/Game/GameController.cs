using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	void Awake ()
    {
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
	}
}
