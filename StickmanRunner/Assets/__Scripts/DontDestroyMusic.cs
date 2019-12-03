using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMusic : MonoBehaviour
{
    // Method to ensure object is not destroyed when level change occurs
    void Awake()
    {
        //search for all objects with Music tag and assign to object array
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
        {
            //Destroy object
            Destroy(this.gameObject);
        }
        // adapted from https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html
        DontDestroyOnLoad(this.gameObject);
    }
}
