using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenManager : MonoBehaviour
{
    //restart game
    public void RestartGame()
    {
        FindObjectOfType<GameController>().ResetGame();
    }

    // Quit Game
    public void QuitGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
