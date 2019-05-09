using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
   private TextMeshProUGUI scoreText;
   GameSession gameSession;

   private void Start()
   {
       scoreText = GetComponent<TextMeshProUGUI>();
       gameSession = FindObjectOfType<GameSession>();
   }

    private void Update() 
    {
       scoreText.text = gameSession.score.ToString(); 
    }
   
}
