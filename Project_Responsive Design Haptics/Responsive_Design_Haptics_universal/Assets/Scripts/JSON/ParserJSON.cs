using System.Collections        ;
using UnityEngine;
using System.Collections.Generic;
using System.IO                 ;
using LitJson                   ;

public class ParserJSON : MonoBehaviour 
{
    private string JSONstring;
    private JsonData FileData;

    void Start()
    {
        JSONstring = File.ReadAllText("./Haptic_style_sheet_v1.jsonc") ;
        Debug.Log(JSONstring);
    } 
}

public class JSONGrammar    
{
    public string id;
    public string type;
    public string class_JSON;
    public List<ParamFormat> params_JSON;
}

public class ParamFormat
{
    public string device;
    public bool enabled;
    public string metrics;
}