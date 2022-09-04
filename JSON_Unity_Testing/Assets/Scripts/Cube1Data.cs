using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;
using System.IO                 ;


public class Cube1Data : MonoBehaviour
{

    public GameObject Cube1 ;

    //private float Pos_X = 0 ;
    //private float Pos_Y = 1 ;
    //private float Pos_Z = 0 ;

    //private float Scale_X = 1 ;
    //private float Scale_Y = 1 ;
    //private float Scale_Z = 1 ;

    //private float speed_X = 0 ;
    //private float speed_Y = 0 ;
    //private float speed_Z = 0 ;

    //private string EnableGravity = "no";

    Vector3 m_position;
    Vector3 m_scale   ;
    Vector3 m_speed   ;
    string m_gravity  ;


    void Start()
    {

        //Cube1.transform.position = new Vector3(Pos_X, Pos_Y, Pos_Z)         ;  // Position setting //
        //Cube1.transform.localScale = new Vector3(Scale_X, Scale_Y, Scale_Z) ;  // Scale setting    //

        //if (EnableGravity == "yes"){
        //    Cube1.GetComponent<Rigidbody>().useGravity = true ;  // Gravity enabling //
        //}

        //if (EnableGravity == "no"){
        //    Cube1.GetComponent<Rigidbody>().useGravity = false ;  // Gravity enabling //
        //}


        Debug.Log("GameHandler.start") ;
        string json = File.ReadAllText(Application.dataPath + "/Cube1Experience.json");
        PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(json)          ;
        Debug.Log("position: "+loadedPlayerData.position);
        Debug.Log("scale: "+loadedPlayerData.scale)      ;
        Debug.Log("speed: "+loadedPlayerData.speed)      ;
        Debug.Log("gravity: "+loadedPlayerData.gravity)  ;

        m_position = new Vector3(loadedPlayerData.position.x, loadedPlayerData.position.y, loadedPlayerData.position.z);
        m_scale = new Vector3(loadedPlayerData.scale.x, loadedPlayerData.scale.y, loadedPlayerData.scale.z)            ;
        m_speed = new Vector3(loadedPlayerData.speed.x, loadedPlayerData.speed.y, loadedPlayerData.speed.z)            ;
        m_gravity = loadedPlayerData.gravity;

        Cube1.transform.position = new Vector3(m_position.x, m_position.y, m_position.z) ;
        Cube1.transform.localScale = new Vector3(m_scale.x, m_scale.y, m_scale.z)        ;


        if (m_gravity == "yes"){
            Cube1.GetComponent<Rigidbody>().useGravity = true ;  // Gravity enabling //
        }

        if (m_gravity == "no" || m_gravity == null){
            Cube1.GetComponent<Rigidbody>().useGravity = false ;  // Gravity enabling //
        }

    }

    
    void Update()
    {
        Cube1.transform.Rotate(m_speed.x, m_speed.y, m_speed.z, Space.World);  // Speed setting //
    }

    
    private class PlayerData
    {
        public Vector3 position;
        public Vector3 scale   ;
        public Vector3 speed   ;
        public string gravity  ;
    }
}
