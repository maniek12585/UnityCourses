﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int _score;

    public int score
    {
        get { return _score; }
        set { _score = value; }
    }
   private void Awake()
   {
       SetUpSingleton();
   }

   private void SetUpSingleton()
   {
       int numberOfGameSessions =FindObjectsOfType<GameSession>().Length;
       if(numberOfGameSessions > 1)
       {
           Destroy(gameObject);
       }else
       {
           DontDestroyOnLoad(gameObject);
       }

   }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }


}
