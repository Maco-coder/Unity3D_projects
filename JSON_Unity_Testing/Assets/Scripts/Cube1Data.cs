using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;
using System.IO                 ;


public class Cube1Data : MonoBehaviour
{

    public GameObject Cube1 ;
    
    private float Pos_X = 0 ;
    private float Pos_Y = 1 ;
    private float Pos_Z = 0 ;

    private float Scale_X = 1 ;
    private float Scale_Y = 1 ;
    private float Scale_Z = 1 ;

    private float speed_X = 0 ;
    private float speed_Y = 0 ;
    private float speed_Z = 0 ;

    private string EnableGravity = "no";


    void Start()
    {
        Debug.Log("GameHandler.start")  ;
        string json = File.ReadAllText(Application.dataPath + "/CubeExperience.json");
        PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(json)         ;
        Debug.Log("position: "+loadedPlayerData.position);
        Debug.Log("scale: "+loadedPlayerData.scale)      ;
        Debug.Log("speed: "+loadedPlayerData.speed)      ;
        Debug.Log("gravity: "+loadedPlayerData.gravity)  ;

        
        Cube1.transform.position = new Vector3(Pos_X,Pos_Y,Pos_Z)          ;  // Position setting //
        Cube1.transform.localScale = new Vector3(Scale_X, Scale_Y, Scale_Z);  // Scale setting    //

        if (EnableGravity == "yes"){
            Cube1.GetComponent<Rigidbody>().useGravity = true ;  // Gravity enabling //
        }

        if (EnableGravity == "no"){
            Cube1.GetComponent<Rigidbody>().useGravity = false ;  // Gravity enabling //
        }
    }

    
    void Update()
    {
        //Cube1.transform.Rotate(scale.x, scale.y, scale.z) ;
        Cube1.transform.Rotate(speed_X, speed_Y, speed_Z, Space.World);  // Speed setting //
    }

    
    private class PlayerData
    {
        public Vector3 position;
        public Vector3 scale   ;
        public Vector3 speed   ;
        public string gravity  ;
    }
}
