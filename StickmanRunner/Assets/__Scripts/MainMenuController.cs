﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Image helpInfo;
    public Text helpText;
    public void Start()
    {
        if (PlayerPrefs.HasKey("MutedSFX"))
        {
            PlayerPrefs.SetString("MutedSFX", PlayerPrefs.GetString("MutedSFX"));
        }
        else 
        { 
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
        SceneManager.LoadScene("Options Menu");
    }

    public void HelpMenu()
    {
        if (helpInfo.enabled)
        {
            helpInfo.enabled = false;
            helpText.enabled = false;
        }
        else 
        {
            helpInfo.enabled = true;
            helpText.enabled = true;
        }

    }

    public void QuitGame()
    {
        //Quit game - adopted from https://docs.unity3d.com/ScriptReference/Application.Quit.html
        Application.Quit();
    }
}
