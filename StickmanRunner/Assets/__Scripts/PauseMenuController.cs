using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pausemenu;
    public GameObject deathmenu;
    private bool deathMenuwasActive=false;

    //Resume Game
    public void ResumeGame()
    {
        //set timescale to 1, resuming all movement
        Time.timeScale = 1f;
        //set pause menu to be inactive
        pausemenu.SetActive(false);
        //if death menu was active
        if (deathMenuwasActive) {
            //then reset it to active upon unpausing
            deathmenu.SetActive(true);
            //reset deathmenuwasactive value
            deathMenuwasActive = false;
        }
    }

    //Pause Game
    public void PauseGame()
    {
        //set timescale to 0, pausing all movement - references/adopted from https://answers.unity.com/questions/1230216/a-proper-way-to-pause-a-game.html && https://docs.unity3d.com/ScriptReference/Time-timeScale.html
        Time.timeScale = 0f;
        //set pause menu to be active
        pausemenu.SetActive(true);

        //if player has died, death menu will be active - adapted from https://docs.unity3d.com/ScriptReference/GameObject-activeSelf.html
        if (deathmenu.activeSelf) {
            //turn off death menu
            deathmenu.SetActive(false);
            //set deathmenuwas active to true, used to restore death menu for user - prevents user being left with no menu before a reset upon death
            deathMenuwasActive = true;
        }
    }

    //Restart Game
    public void RestartGame()
    {
        // Set timescale to 1, resuming all movement
        Time.timeScale = 1f;
        // Set pause menu to be active
        pausemenu.SetActive(false);
        //Set deathmenuwasactive to false, to ensure user cant restart while variable is set active
        // will result in deathmenu displaying if not resetting value
        deathMenuwasActive = false;
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
