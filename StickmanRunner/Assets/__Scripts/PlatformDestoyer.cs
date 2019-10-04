using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestoyer : MonoBehaviour
{
    public GameObject destructionPoint;
    void Start()
    {
        //Find object by name so doesnt need attachment to each platform;
        destructionPoint = GameObject.Find("DestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {
        //if platforms x position is less than the destruction points x position.
        if (transform.position.x < destructionPoint.transform.position.x)
        {
            //Destroy the object the script is attached to
            Destroy(gameObject);
        }
    }
}
