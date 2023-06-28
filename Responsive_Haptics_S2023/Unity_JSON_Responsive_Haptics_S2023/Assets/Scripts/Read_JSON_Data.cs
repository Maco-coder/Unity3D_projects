using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;
using System.IO                 ;
using LitJson                   ;


public class Read_JSON_Data : MonoBehaviour
{
    public GameObject Cube1 ;

    Vector3 m_position;
    Vector3 m_scale   ;
    Vector3 m_speed   ;
    string m_gravity  ;
    string[] m_tests  ;
    string m_program  ;
    string m_name     ;


    void Start()
    {

        Debug.Log("GameHandler.start") ;
        string json = File.ReadAllText(Application.dataPath + "/Cube1Experience.json");
        PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(json)          ;
        Debug.Log("position: "+loadedPlayerData.position);
        Debug.Log("scale: "+loadedPlayerData.scale)      ;
        Debug.Log("speed: "+loadedPlayerData.speed)      ;
        Debug.Log("gravity: "+loadedPlayerData.gravity)  ;

        Debug.Log("tests: "+loadedPlayerData.tests[0]) ;

        m_position = new Vector3(loadedPlayerData.position.x, loadedPlayerData.position.y, loadedPlayerData.position.z);
        m_scale = new Vector3(loadedPlayerData.scale.x, loadedPlayerData.scale.y, loadedPlayerData.scale.z)            ;
        m_speed = new Vector3(loadedPlayerData.speed.x, loadedPlayerData.speed.y, loadedPlayerData.speed.z)            ;
        m_gravity = loadedPlayerData.gravity  ;

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
        public string[] tests  ;
        public string name     ;
        public string program  ;
    }

}