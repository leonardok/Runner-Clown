﻿using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    Animator anim;
    bool isGameOver = false;
    float restartTimer = 0;
    float restartDelay = 5.0f;


    void Awake()
    {
        anim = GameObject.Find("HUDCanvas").GetComponent<Animator>();
    }

    void Update ()
    {
        // If the player has run out of health...
        if(isGameOver)
        {
            // ... tell the animator the game is over.
            anim.SetTrigger ("GameOver");
            
            // .. increment a timer to count up to restarting.
            restartTimer += Time.deltaTime;
            
            // .. if it reaches the restart delay...
            if(restartTimer >= restartDelay)
            {
                // .. then reload the currently loaded level.
                restartLevel();
            }
        }
    }

    public void restartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }


    public static void GameOverScreen ()
    {
        // ... tell the animator the game is over.
        GameObject.Find("_GM").GetComponent <GameOverManager> ().isGameOver = true;
    }
}