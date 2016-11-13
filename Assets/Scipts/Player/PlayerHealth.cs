using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
 
    enum state{ alive, dead}
    enum mode { introduction,countdownBegin,menu,play,pause,endGame} 
    int score;
    state etat;
    public int life;
    public GameObject shield;
    GameObject gameControler;
   
    void Start()
    {
        gameControler = GameObject.FindGameObjectWithTag("GameController");
        etat = state.alive;
        score = 0;
    }

    void Update()
    {
        if (etat != state.dead && life<=0)
        {
            Die();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer ==9 )
        {
            life --;
            Destroy(other.gameObject);
        }
       
    }

    public void Die()
    {
        GetComponent<Animator> ().SetTrigger ("Death");
        GetComponent<PlayerShooter> ().enabled = false;
        GetComponent<PlayerMovement> ().enabled = false;
        Destroy (shield);

        gameControler.GetComponent<GameController>().DeadPlayerNotifier(GetComponent<PlayerIdentity>().playerName);

        etat = state.dead;
    }
}
