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
    // Start is called before the first frame update
    void Start()
    {
        //get the platform width from the platforms using the box collider
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
    }

    void Update()
    {
        if (transform.position.x < spawnPoint.position.x)
        {
            //set distance to random number between two values given
            distance = Random.Range(minDistance, maxDistance);

            //Change the spawnpoint of the platforms equal to the distance set between them + the width of the platforms,
            //so that they spawn off screen for the user's experience.
            transform.position = new Vector3(transform.position.x + platformWidth + distance, transform.position.y, 0);

            //spawn the platforms in, at the new spawnpoint
            Instantiate(platform, transform.position, transform.rotation);
        }
    }
}
