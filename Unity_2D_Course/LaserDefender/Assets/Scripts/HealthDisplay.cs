using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
   private TextMeshProUGUI healthText;
   Player player;

   private void Start()
   {
       healthText = GetComponent<TextMeshProUGUI>();
       player = FindObjectOfType<Player>();
   }

    private void Update() 
    {
       healthText.text = player.GetPlayerHealth().ToString(); 
    }
}
