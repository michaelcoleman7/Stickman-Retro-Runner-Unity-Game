using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Image unmutedSFXImg;
    public Image unmutedMusicImg;

    public void MuteMusic()
    {
        //If the player pref value for mute is set to false
        if (PlayerPrefs.GetString("Muted") == "false")
        {
            //set mute playerpref value to true
            PlayerPrefs.SetString("Muted", "true");
            unmutedMusicImg.enabled = false;
            //Set the music change value to true to initiate the change in Music Controller
            PlayerPrefs.SetString("MusicChange", "true");
        }
        //If the player pref value for mute is set to true
        else if (PlayerPrefs.GetString("Muted") == "true")
        {
            //set mute playerpref value to false
            PlayerPrefs.SetString("Muted", "false");
            unmutedMusicImg.enabled = true;
            //Set the music change value to true to initiate the change in Music Controller
            PlayerPrefs.SetString("MusicChange", "true");
        }
            
    }

    public void MuteSFX()
    {

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
