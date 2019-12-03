using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Image helpInfo;
    public Text helpText;
    public Text helpText2;
    public void Start()
    {
        if (PlayerPrefs.HasKey("MutedSFX"))
        {
            //If key already exists in player prefernces, then load it in as the muted value
            PlayerPrefs.SetString("MutedSFX", PlayerPrefs.GetString("MutedSFX"));
        }
        else 
        { 
            //Set muted sound effects to false if the key doesnt exist
            PlayerPrefs.SetString("MutedSFX", "false");
        }
        
    }
    public void PlayGame()
    {
        //load up the main game scene - adopted from https://answers.unity.com/questions/44806/unity-script-to-open-a-new-scene.html
        SceneManager.LoadScene("Main Game");
    }

    public void OptionsMenu()
    {
        // Load options menu scene
        SceneManager.LoadScene("Options Menu");
    }

    public void HelpMenu()
    {
        //If UI is already enabled when user presses help button
        if (helpInfo.enabled)
        {
            //disable all UI info for help/controls information
            helpInfo.enabled = false;
            helpText.enabled = false;
            helpText2.enabled = false;
        }
        //if UI is disabled when user presses help button
        else 
        {
            //enable all UI info for help/controls information
            helpInfo.enabled = true;
            helpText.enabled = true;
            helpText2.enabled = true;
        }

    }

    public void QuitGame()
    {
        //Quit game - adopted from https://docs.unity3d.com/ScriptReference/Application.Quit.html
        Application.Quit();
    }
}
