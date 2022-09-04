using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;
using System.IO                 ;



public class Cube2Data : MonoBehaviour
{

    public GameObject Cube2    ;
    public TextAsset  textJSON ;


    [System.Serializable]
    public class Data
    {
        public string type     ;
        public string magnitude;
        public string geometry ;
    }

    [System.Serializable]
    public class List
    {
        public Data[] feedback ;

    }

    public List myFeedbackList = new List();


    void Start()
    {
        myFeedbackList = JsonUtility.FromJson<List>(textJSON.text);


        //Debug.Log("GameHandler.start") ;
        Debug.Log(myFeedbackList.feedback.[1]["type"]);

        //m_position = new Vector3(loadedPlayerData.position.x, loadedPlayerData.position.y, loadedPlayerData.position.z);
        //m_scale = new Vector3(loadedPlayerData.scale.x, loadedPlayerData.scale.y, loadedPlayerData.scale.z)            ;
        //m_speed = new Vector3(loadedPlayerData.speed.x, loadedPlayerData.speed.y, loadedPlayerData.speed.z)            ;
        //m_gravity = loadedPlayerData.gravity;

        //Cube2.transform.position = new Vector3(m_position.x, m_position.y, m_position.z) ;
        //Cube2.transform.localScale = new Vector3(m_scale.x, m_scale.y, m_scale.z)        ;


        //if (m_gravity == "yes"){
        //    Cube2.GetComponent<Rigidbody>().useGravity = true ;  // Gravity enabling //
        //}

        //if (m_gravity == "no" || m_gravity == null){
        //    Cube2.GetComponent<Rigidbody>().useGravity = false ;  // Gravity enabling //
        //}

    }

    
    void Update()
    {
        //Cube2.transform.Rotate(m_speed.x, m_speed.y, m_speed.z, Space.World);  // Speed setting //
    }
}