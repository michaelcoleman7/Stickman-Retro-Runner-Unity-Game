using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenManager : MonoBehaviour
{
    
    public void RestartGame()
    {
        FindObjectOfType<GameController>().ResetPlayer();
    }

    // Quit Game
    public void QuitGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
