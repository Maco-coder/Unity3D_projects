using System.IO                 ;
using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;


public class JSON_testing : MonoBehaviour
{
    
    private void Start()
    {
        Debug.Log("GameHandler.start")  ;

        // GENERATING A JSON FILE FROM PARAMETERS INPUTTED IN UNITY //
        /*
        PlayerData playerData = new PlayerData();
        playerData.position = new Vector3(5,0);
        playerData.acceleration = 80;

        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);

        File.WriteAllText(Application.dataPath + "FileJson.json", json);
        */

        // EXTRACTING PARAMETERS FROM A JSON FILE AND PARSE THEM INTO GAME OBJECTS //

        string json = File.ReadAllText(Application.dataPath + "/CubeExperience.json");
        PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(json)   ;
        Debug.Log("position: "+loadedPlayerData.position);
        Debug.Log("scale: "+loadedPlayerData.scale)      ;
        Debug.Log("speed: "+loadedPlayerData.scale)      ;
        Debug.Log("gravity: "+loadedPlayerData.gravity)  ;
    }

    private class PlayerData
    {
        public Vector3 position;
        public Vector3 scale   ;
        public Vector3 speed   ;
        public string gravity  ;
    }

}
