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

    // Start is called before the first frame update
    void Start()
    {
        platformStartPosition = platformGenerator.position;
        playerStartPosition = player.transform.position;

        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame() 
    {
        //adopted from https://docs.unity3d.com/Manual/Coroutines.html
        StartCoroutine("RestartGameCoRoutine");
    }

    //adopted from https://docs.unity3d.com/Manual/Coroutines.html
    public IEnumerator RestartGameCoRoutine() 
    {
        // Stop score increasing
        scoreManager.increaseScore = false;

        //set player to invisible to create illusion of death
        player.gameObject.SetActive(false);

        //add wait period so user is not disorientated - adopted from https://answers.unity.com/questions/885849/how-to-respawn-with-a-simple-delay.html
        yield return new WaitForSeconds(0.5f);

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

        scoreManager.scoreValue = 0;
        scoreManager.increaseScore = true;

    }
}
