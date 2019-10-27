using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public AudioSource musicAudioSource;
    void Start()
    {
        if (PlayerPrefs.HasKey("Muted"))
        {
            //Set up audio using previously saved user configurations
            PlayerPrefs.SetString("Muted", PlayerPrefs.GetString("Muted"));
            PlayerPrefs.SetString("MusicChange", "true");
        }
        else
        {
            //set initial value of muted if does not currently exist
            PlayerPrefs.SetString("Muted", "false");
        }
    }

    void Update()
    {
        //If change has been initiated in the SettingsController - then update mute music option
        if (PlayerPrefs.GetString("MusicChange") == "true")
        {
            //If mute value has been set to true in SettingsController, then set audio source to true
            if (PlayerPrefs.GetString("Muted") == "true")
            {
                //Mute music
                musicAudioSource.mute = true;
            }
            //If mute value has been set to false in SettingsController, then set audio source to false
            else if (PlayerPrefs.GetString("Muted") == "false")
            {
                //Unmute music
                musicAudioSource.mute = false;
            }
            //Reset value of MusicChange to avoid constant updates when user has not made a change to audio preferences
            PlayerPrefs.SetString("MusicChange", "false");
        }

    }
}
