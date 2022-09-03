using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class VIVEJSONtesting : MonoBehaviour
{
    private void Start(){
        Debug.Log("GameHandler.start") ;
        string json = File.ReadAllText(Application.dataPath + "/JSON2-device_output.json");
        PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(json) ;
        Debug.Log("grabbing apple: "+loadedPlayerData.grab_bump);
        Debug.Log("scale: "+loadedPlayerData.scale)      ;
        Debug.Log("speed: "+loadedPlayerData.speed)      ;
        Debug.Log("gravity: "+loadedPlayerData.gravity)  ;
    }
    




    private class PlayerData
    {
        public Vector3 grab_bump;
        public Vector3 scale    ;
        public Vector3 speed    ;
        public bool gravity     ;
    }
}
