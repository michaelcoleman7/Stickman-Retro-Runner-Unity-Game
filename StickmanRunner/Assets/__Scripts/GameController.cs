using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartPosition;

    public CharacterMovement player;
    private Vector3 playerStartPosition;

    private PlatformDestoyer[] platformList;

    private ScoreManager scoreManager;

    public DeathScreenManager deathScreen;

    // Start is called before the first frame update
    void Start()
    {
        platformStartPosition = platformGenerator.position;
        playerStartPosition = player.transform.position;

        scoreManager = FindObjectOfType<ScoreManager>();
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

    public void ResetPlayer()
    {
        //Turn off death screen
        deathScreen.gameObject.SetActive(false); 

        platformList = FindObjectsOfType<PlatformDestoyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        //mobve player and platform generators to their origional positions
        player.transform.position = playerStartPosition;
        platformGenerator.position = platformStartPosition;


        //Set the player visible again to viewer
        player.gameObject.SetActive(true);

        //reset score values
        scoreManager.scoreValue = 0;
        scoreManager.increaseScore = true;
    }
}
