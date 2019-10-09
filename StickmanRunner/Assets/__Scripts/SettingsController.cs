using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    GameObject music = GameObject.FindGameObjectWithTag("Music");
    public AudioSource musicAudioSource;
    public Image unmutedSFXImg;
    public Image unmutedMusicImg;

    public void MuteMusic()
    {
        if (musicAudioSource.mute == false)
        {
            musicAudioSource.mute = true;
            unmutedMusicImg.enabled = false;
        }
        else 
        {
            musicAudioSource.mute = false;
            unmutedMusicImg.enabled = true;
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
