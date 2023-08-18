using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;
using System.IO                 ;
using LitJson                   ;

public class NewBehaviourScript : MonoBehaviour
{
    private string JSONstring;
    private JsonData FileData;


    void Start()
    {
        JSONstring = File.ReadAllText(Application.dataPath + "/Cube1Experience.json") ;
        FileData = JsonMapper.ToObject(JSONstring) ;
        Debug.Log(FileData["tests"][1]["name"])    ;
    }

    void Update()
    {
        
    }
}
