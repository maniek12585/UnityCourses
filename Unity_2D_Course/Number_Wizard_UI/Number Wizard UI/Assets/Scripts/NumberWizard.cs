using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NumberWizard : MonoBehaviour
{
    [SerializeField]int max ;
    [SerializeField]int min ;
    [SerializeField] TextMeshProUGUI guessText;  //displaying text on text mesh pro 
    int guess ;
    int guessedNumber;
    void StartGame()
    {
        NextGuess();
    }
    void NextGuess()
    {
        guess=Random.Range(min,max+1);
        guessText.text=guess.ToString();
    }
    public void OnPressHigher()
    {
        min = guess+1;
        NextGuess();
    }
    public void OnPressLower()
    {
        max = guess-1;
        NextGuess();
    }


    // Start is called before the first frame update

    void Start()
    {
        StartGame();
    }

}
