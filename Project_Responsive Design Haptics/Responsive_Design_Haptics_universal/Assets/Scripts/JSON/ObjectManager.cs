using System.Collections        ;
using UnityEngine;
using System.Collections.Generic;
using System.IO                 ;
using LitJson                   ;
public class ObjectManager : MonoBehaviour 
{
    private string JSONstring;
    private JsonData FileData;
    private JsonData ParamData;
    public int device;
    public int count_devices;

    void Start()
    {
        JSONstring = File.ReadAllText("./Assets/Scripts/JSON/Haptic_style_sheet_v1.jsonc") ;
        FileData = JsonMapper.ToObject(JSONstring);
        for (int i = 0; i < FileData.Count; i++)    {
            string id = (string) FileData[i]["id"];
            string type = (string) FileData[i]["type"];
            string class_JSON = (string) FileData[i]["class"];
            List<string> params_JSON;
            for (int j = 0; j < count_devices; j++) {
                string param = (string) FileData[i]["params"][j];
                params_JSON.Add(param);
            }
            // This is for tool-related JSON data
            if (class_JSON == "object")   {
                switch (type) {
                case "script":
                    if (transform.Find(id)) 
                        StartScript(id, params_JSON);
                    break;
                case "collider":
                    if (transform.Find(id)) 
                        StartCollider(id, params_JSON);
                    break;
                case "constraint":
                    if (transform.Find(id)) 
                        StartConstraint(id, params_JSON);
                    break;
                }
            }
        }
    } 

    void StartScript(string id, List<string> params_JSON)   
    {
        ParamData = JsonMapper.ToObject(params_JSON);
        switch(device) 
        {
            // TODO: Write search function for indexing ParamData by device
            case 1: // VR-Controller
                GetComponent<id>().enabled = ParamData[2]["enabled"];
                break;
            case 2: // Stylus
                GetComponent<id>().enabled = ParamData[1]["enabled"];
                break;
            case 3: // Prop
                GetComponent<id>().enabled = ParamData[0]["enabled"];
                break;
        }
    }

    void StartCollider(string id, List<string> params_JSON)
    {
        ParamData = JsonMapper.ToObject(params_JSON);
        switch(device)  
        {
            // TODO: Write search function for indexing ParamData by device
            case 1: // VR-Controller
                GetComponent<id>().SetActive(ParamData[2]["enabled"]);
                if (ParamData[2]["metrics"])    
                {
                    Vector3 position, rotation, scale;
                    position = new Vector3(ParamData[2]["metrics"]["transform"]["position"]["x"], ParamData[2]["metrics"]["transform"]["position"]["y"], ParamData[2]["metrics"]["transform"]["position"]["z"]);
                    rotation = new Vector3(ParamData[2]["metrics"]["transform"]["rotation"]["x"], ParamData[2]["metrics"]["transform"]["rotation"]["y"], ParamData[2]["metrics"]["transform"]["rotation"]["z"]);
                    scale = new Vector3(ParamData[2]["metrics"]["transform"]["scale"]["x"], ParamData[2]["metrics"]["transform"]["scale"]["y"], ParamData[2]["metrics"]["transform"]["scale"]["z"]);
                    if (ParamData[2]["metrics"]["transform"]["origin"] == "relative")   
                    {
                        // Set everything using local transform variables
                        GetComponent<id>().transform.localPosition = position;
                        GetComponent<id>().transform.localRotation = rotation;
                        GetComponent<id>().transform.localScale = scale;
                    }
                    else
                    {
                        // Set everything using global transform variables
                        GetComponent<id>().transform.position = position;
                        GetComponent<id>().transform.rotation = rotation;
                        GetComponent<id>().transform.scale = scale;                        
                    }
                }
                break;
            case 2: // Stylus
                GetComponent<id>().SetActive(ParamData[1]["enabled"]);
                if (ParamData[1]["metrics"])
                {
                    Vector3 position, rotation, scale;
                    position = new Vector3(ParamData[1]["metrics"]["transform"]["position"]["x"], ParamData[1]["metrics"]["transform"]["position"]["y"], ParamData[1]["metrics"]["transform"]["position"]["z"]);
                    rotation = new Vector3(ParamData[1]["metrics"]["transform"]["rotation"]["x"], ParamData[1]["metrics"]["transform"]["rotation"]["y"], ParamData[1]["metrics"]["transform"]["rotation"]["z"]);
                    scale = new Vector3(ParamData[1]["metrics"]["transform"]["scale"]["x"], ParamData[1]["metrics"]["transform"]["scale"]["y"], ParamData[1]["metrics"]["transform"]["scale"]["z"]);
                    if (ParamData[1]["metrics"]["transform"]["origin"] == "relative")   
                    {
                        // Set everything using local transform variables
                        GetComponent<id>().transform.localPosition = position;
                        GetComponent<id>().transform.localRotation = rotation;
                        GetComponent<id>().transform.localScale = scale;
                    }   
                    else
                    {
                        // Set everything using global transform variables
                        GetComponent<id>().transform.position = position;
                        GetComponent<id>().transform.rotation = rotation;
                        GetComponent<id>().transform.scale = scale;                        
                    }                 
                }
                break;
            case 3: // Props
                GetComponent<id>().SetActive(ParamData[0]["enabled"]);
                if (ParamData[0]["metrics"])
                {
                    Vector3 position, rotation, scale;
                    position = new Vector3(ParamData[0]["metrics"]["transform"]["position"]["x"], ParamData[0]["metrics"]["transform"]["position"]["y"], ParamData[0]["metrics"]["transform"]["position"]["z"]);
                    rotation = new Vector3(ParamData[0]["metrics"]["transform"]["rotation"]["x"], ParamData[0]["metrics"]["transform"]["rotation"]["y"], ParamData[0]["metrics"]["transform"]["rotation"]["z"]);
                    scale = new Vector3(ParamData[0]["metrics"]["transform"]["scale"]["x"], ParamData[0]["metrics"]["transform"]["scale"]["y"], ParamData[0]["metrics"]["transform"]["scale"]["z"]);
                    if (ParamData[0]["metrics"]["transform"]["origin"] == "relative")   
                    {
                        // Set everything using local transform variables
                        GetComponent<id>().transform.localPosition = position;
                        GetComponent<id>().transform.localRotation = rotation;
                        GetComponent<id>().transform.localScale = scale;
                    } 
                    else
                    {
                        // Set everything using global transform variables
                        GetComponent<id>().transform.position = position;
                        GetComponent<id>().transform.rotation = rotation;
                        GetComponent<id>().transform.scale = scale;                        
                    }
                }
        }
    }

    void StartConstraint(string id, List<string> params_JSON)
    {
        ParamData = JsonMapper.ToObject(params_JSON);
        switch(device)
        {
            case 1: // VR-Controller
                GetComponent<id>().SetActive(ParamData[2]["enabled"]);
                if (ParamData[2]["metrics"])    
                {
                    switch(ParamData[2]["metrics"]["constraint-type"]) 
                    {
                        case "SpringJoint":
                            GetComponent<id>().spring = ParamData[2]["metrics"]["spring"];
                            GetComponent<id>().damper = ParamData[2]["metrics"]["damper"];
                            GetComponent<id>().breakTorque = ParamData[2]["metrics"]["breakTorque"];
                            GetComponent<id>().breakForce = ParamData[2]["metrics"]["breakForce"];
                            break;
                    }
                }
                break;
            case 2: // Stylus
                GetComponent<id>().SetActive(ParamData[1]["enabled"]);
                if (ParamData[1]["metrics"])
                {
                    switch(ParamData[1]["metrics"]["constraint-type"]) 
                    {
                        case "SpringJoint":
                            GetComponent<id>().spring = ParamData[1]["metrics"]["spring"];
                            GetComponent<id>().damper = ParamData[1]["metrics"]["damper"];
                            GetComponent<id>().breakTorque = ParamData[1]["metrics"]["breakTorque"];
                            GetComponent<id>().breakForce = ParamData[1]["metrics"]["breakForce"];
                            break;
                    }                    
                }
                break;
            case 3: // Props
                GetComponent<id>().SetActive(ParamData[0]["enabled"]);
                if (ParamData[0]["metrics"])    
                {
                    switch(ParamData[0]["metrics"]["constraint-type"])
                    {
                        case "SpringJoint":
                            GetComponent<id>().spring = ParamData[0]["metrics"]["spring"];
                            GetComponent<id>().damper = ParamData[0]["metrics"]["damper"];
                            GetComponent<id>().breakTorque = ParamData[0]["metrics"]["breakTorque"];
                            GetComponent<id>().breakForce = ParamData[0]["metrics"]["breakForce"];
                            break;
                    }
                }
                break;
        }
    }
}
