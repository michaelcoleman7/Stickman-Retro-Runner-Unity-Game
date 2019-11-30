using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour
{
    public GameObject platform;
    public Transform spawnPoint;
    private float distance;
    public float minDistance;
    public float maxDistance;
    private float platformWidth;

    private float minHeight;
    private float maxHeight;
    public Transform maxSpawnHeight;
    private float heightDifference;
    public float maxHeightDifference;

    public GameObject trapPlatform1;
    public GameObject trapPlatform2; 
    public GameObject spikePlatform; 
    private float trapRange;
    // Start is called before the first frame update
    void Start()
    {
        //get the platform width from the platforms using the box collider
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;

        minHeight = transform.position.y;
        maxHeight = maxSpawnHeight.position.y;
    }

    void Update()
    {
        if (transform.position.x < spawnPoint.position.x)
        {
            //set distance to random number between two values given
            distance = Random.Range(minDistance, maxDistance);

            heightDifference = transform.position.y + Random.Range(maxHeightDifference, -maxHeightDifference);
            if (heightDifference > maxHeight)
            {
                heightDifference = maxHeight;
            }
            else if (heightDifference < minHeight) 
            {
                heightDifference = minHeight;
            }

            //Change the spawnpoint of the platforms equal to the distance set between them + the width of the platforms,
            //so that they spawn off screen for the user's experience.
            transform.position = new Vector3(transform.position.x + platformWidth + distance, heightDifference, 0);

            //spawn the platforms in, at the new spawnpoint
            //Instantiate(trap, transform.position, transform.rotation);
            Instantiate(platform, transform.position, transform.rotation);

            //set trapRange to a random value between 1 and 10
            trapRange = Random.Range(0, 10);

            if (trapRange > 5)
            {
                //set random value to boolean variable - https://gamedev.stackexchange.com/questions/110332/is-there-a-random-command-for-boolean-variables-in-unity-c
                bool leftTrap = (Random.value > 0.5f);
                if (leftTrap)
                {
                    bool spikeTrap = (Random.value > 0.5f);
                    if (spikeTrap)
                    {
                        Instantiate(spikePlatform, transform.position, transform.rotation);
                    }
                    else
                    {
                        //spawn in trap platform 1
                        Instantiate(trapPlatform1, transform.position, transform.rotation);
                    }
                }
                else
                {
                    bool spikeTrap = (Random.value > 0.5f);
                    if (spikeTrap) {
                        Instantiate(spikePlatform, transform.position, transform.rotation);
                    }
                    else{
                        //spawn in trap platform 2
                        Instantiate(trapPlatform2, transform.position, transform.rotation);
                    }
                }
            }
            else 
            {
                ////spawn in regular platform
                Instantiate(platform, transform.position, transform.rotation);
            }
        }
    }
}
