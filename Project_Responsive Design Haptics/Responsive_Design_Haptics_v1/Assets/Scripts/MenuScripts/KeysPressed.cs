using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysPressed : MonoBehaviour
{

    public GameObject playerVR;
    
    void Start()
    {
        playerVR.SetActive (false);
    }

    void Update()
    {
        if (Input.GetKeyDown("space")){
            playerVR.SetActive(true);
        }
    }
}
