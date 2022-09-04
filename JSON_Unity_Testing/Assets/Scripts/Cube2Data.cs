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

        print(myFeedbackList.feedback[0].type);

    }

    
    void Update()
    {
        //Cube2.transform.Rotate(m_speed.x, m_speed.y, m_speed.z, Space.World);  // Speed setting //
    }
}