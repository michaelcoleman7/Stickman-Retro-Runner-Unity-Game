﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform platformGenerator;
    public Transform deathPlatformGenerator;
    private Vector3 platformStartPosition;
    private Vector3 deathPlatformStartPosition;

    public CharacterController player;
    private Vector3 playerStartPosition;

    private PlatformDestoyer[] platformList;

    private ScoreManager scoreManager;

    public DeathScreenManager deathScreen;

    public PauseMenuController pauseMenuController;

    // Start is called before the first frame update
    void Start()
    {
        //save start position for starting platform for game reset
        platformStartPosition = platformGenerator.position;
        //save death platform start position for reset
        deathPlatformStartPosition = deathPlatformGenerator.position;
        // save the players start position for a restart
        playerStartPosition = player.transform.position;

        //find the score manager object by type - adpated from: https://docs.unity3d.com/ScriptReference/Object.FindObjectOfType.html
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        //If escape button is pressed then pause the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //call PauseMenuController method to pause game
            pauseMenuController.PauseGame();
        }
    }
    public void RestartGame() 
    {
        // Stop score increasing after death
        scoreManager.increaseScore = false;

        //set player to invisible to create illusion of death
        player.gameObject.SetActive(false);

        //make death screen visible to player
        deathScreen.gameObject.SetActive(true);
    }

    public void ResetGame()
    {
        //Turn off death screen
        deathScreen.gameObject.SetActive(false); 

        platformList = FindObjectsOfType<PlatformDestoyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            //set all objects to false which are supposed to be destroyed
            platformList[i].gameObject.SetActive(false);
        }

        //mobve player and platform generators to their origional positions
        player.transform.position = playerStartPosition;
        platformGenerator.position = platformStartPosition; 
        deathPlatformGenerator.position = deathPlatformStartPosition;


        //Set the player visible again to viewer
        player.gameObject.SetActive(true);

        //reset score values
        scoreManager.scoreValue = 0;
        scoreManager.increaseScore = true;
    }
}
