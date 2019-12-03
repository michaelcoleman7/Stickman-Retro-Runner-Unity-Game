using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public float cameraDistance;
    // Start is called before the first frame update
    void Awake()
    {
        //change the camera size to allow fitting of the screen - adapted from https://docs.unity3d.com/ScriptReference/Camera.html and https://docs.unity3d.com/ScriptReference/Screen.html
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move the camera with the players current coordinates
        transform.position = new Vector3(player.position.x + 20, player.position.y, transform.position.z);
    }
}
