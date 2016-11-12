﻿using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
 
    enum state{ alive, dead}
    enum mode { introduction,countdownBegin,menu,play,pause,endGame} 
    int score;
    state etat;
    public int life;
   
    void Start()
    {
        etat = state.alive;
        score = 0;
        life = 1;
    }
      void Update()
    {
        if (life<=0)
        {
            ImDead();
            Debug.Log("gigi");
        }
        Debug.Log(gameObject.layer);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer ==9 )
        {
            life --;
            Destroy(other.gameObject);
        }
       
    }

    public void ImDead()
    {
        etat = state.dead;
        Destroy(gameObject);

    }
}
