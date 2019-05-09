using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private float delayAfterDeath;
    
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
        FindObjectOfType<GameSession>().ResetGame();
    }
    public void LoadGameOverScene()
    {
        StartCoroutine(waitAfterDeath());
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator waitAfterDeath()
    {
        yield return new WaitForSeconds(delayAfterDeath);
        SceneManager.LoadScene("GameOverScene");
    }


}
