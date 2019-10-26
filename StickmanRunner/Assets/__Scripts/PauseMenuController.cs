using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pausemenu;
    //Resume Game
    public void ResumeGame()
    {
        //set timescale to 1, resuming all movement
        Time.timeScale = 1f;
        //set pause menu to be inactive
        pausemenu.SetActive(false);
    }
    //Pause Game
    public void PauseGame()
    {
        //set timescale to 0, pausing all movement - references/adopted from https://answers.unity.com/questions/1230216/a-proper-way-to-pause-a-game.html && https://docs.unity3d.com/ScriptReference/Time-timeScale.html
        Time.timeScale = 0f;
        //set pause menu to be active
        pausemenu.SetActive(true);
    }
    //Restart Game
    public void RestartGame()
    {
        // Set timescale to 1, resuming all movement
        Time.timeScale = 1f;
        /// Set pause menu to be active
        pausemenu.SetActive(false);
        //Find game controller (as there is only one in game) and call reset game function
        FindObjectOfType<GameController>().ResetGame();
    }

    // Quit Game
    public void QuitGame()
    {
        // Set timescale to 1, resuming all movement
        Time.timeScale = 1f;
        // Load main menu scene
        SceneManager.LoadScene("Main Menu");
    }
}
