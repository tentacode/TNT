using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
 
    enum state{ alive, dead}
    enum mode { introduction,countdownBegin,menu,play,pause,endGame} 
    int score;
    string playerName;
    state etat;
    public AudioManager audioManager;
    public int life;
    public GameObject shield;
    GameObject gameControler;
   
    void Start()
    {
        playerName = GetComponent<PlayerIdentity>().playerName;
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
        switch (playerName)
        {
            case "Stranger":
                audioManager.PlayClip(audioManager.StrangerDeath, transform.position);
                break;
            case "Alien Bear":
                audioManager.PlayClip(audioManager.AlienBearDeath, transform.position);
                break;
            case "Scrap":
                audioManager.PlayClip(audioManager.Scrap, transform.position);
                break;
            case "Hunter":
                audioManager.PlayClip(audioManager.Hunter, transform.position);
                break;
        }
        GetComponent<PlayerShooter> ().enabled = false;
        GetComponent<PlayerMovement> ().enabled = false;
        Destroy (shield);

        gameControler.GetComponent<GameController>().DeadPlayerNotifier(GetComponent<PlayerIdentity>().playerName);
       
       
        etat = state.dead;
    }
}
