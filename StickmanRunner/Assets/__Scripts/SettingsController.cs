using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Image unmutedSFXImg;
    public Image unmutedMusicImg;

    void Start()
    {
        CheckMusic();
        CheckSFX();
    }
    public void MuteMusic()
    {
        //If the player pref value for mute is set to false
        if (PlayerPrefs.GetString("Muted") == "false")
        {
            //set mute playerpref value to true
            PlayerPrefs.SetString("Muted", "true");
            //Display the correct image
            unmutedMusicImg.enabled = false;
            //Set the music change value to true to initiate the change in Music Controller
            PlayerPrefs.SetString("MusicChange", "true");
        }
        //If the player pref value for mute is set to true
        else if (PlayerPrefs.GetString("Muted") == "true")
        {
            //set mute playerpref value to false
            PlayerPrefs.SetString("Muted", "false");
            //Display the correct image
            unmutedMusicImg.enabled = true;
            //Set the music change value to true to initiate the change in Music Controller
            PlayerPrefs.SetString("MusicChange", "true");
        }
            
    }

    public void MuteSFX()
    {
        //If the player pref value for MutedSFX is set to false
        if (PlayerPrefs.GetString("MutedSFX") == "false")
        {
            //set MutedSFX playerpref value to true
            PlayerPrefs.SetString("MutedSFX", "true");
            //Display the correct image
            unmutedSFXImg.enabled = false;
        }
        //If the player pref value for MutedSFX is set to true
        else if (PlayerPrefs.GetString("MutedSFX") == "true")
        {
            //set MutedSFX playerpref value to false
            PlayerPrefs.SetString("MutedSFX", "false");
            //Display the correct image
            unmutedSFXImg.enabled = true;
        }
    }

    public void CheckMusic()
    {
        //If music is muted display the correct image
        if (PlayerPrefs.GetString("Muted") == "true")
        {
            unmutedMusicImg.enabled = false;
        }
    }

    public void CheckSFX()
    {
        //If SFX is muted display the correct image
        if (PlayerPrefs.GetString("MutedSFX") == "true")
        {
            unmutedSFXImg.enabled = false;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
