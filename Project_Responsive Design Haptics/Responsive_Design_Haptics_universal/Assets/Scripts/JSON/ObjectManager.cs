using System.Collections        ;
using UnityEngine;
using System.Collections.Generic;
using System.IO                 ;
using LitJson                   ;
using System;
using Valve.VR                   ; // Needed to enable and disable VR trackers //
using Valve.VR.InteractionSystem ; // Needed to enable and disable VR controllers //


public class ObjectManager : MonoBehaviour 
{
    private string JSONstring;
    private JsonData FileData;
    private JsonData ParamData;
    public int device;
    public int count_devices;

    public GameObject object_carabao;

    void Start()
    {
        JSONstring = File.ReadAllText("./Assets/Scripts/JSON/Haptic_style_sheet_v1.jsonc") ;
        FileData = JsonMapper.ToObject(JSONstring);
        for (int i = 0; i < FileData.Count; i++)    {
            string id = (string) FileData[i]["id"];
            string type = (string) FileData[i]["type"];
            string class_JSON = (string) FileData[i]["class"];
            string params_JSON = (string) FileData[i]["params"];
            // List<string> params_JSON = new List<string>;
            // for (int j = 0; j < count_devices; j++) {
            //     string param = (string) FileData[i]["params"][j];
            //     params_JSON.Add(param);
            // }
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

    void StartScript(string id, string params_JSON)   
    {
        ParamData = JsonMapper.ToObject(params_JSON);
        switch(device)
        {
            // TODO: Write search function for indexing ParamData by device
            case 1: // VR-Controller
                // condition on type of script
                switch(id) 
                {
                    case "SteamVR_TrackedObject": 
                        object_carabao.GetComponent<SteamVR_TrackedObject>().enabled = (bool) ParamData[2]["enabled"];
                        break;
                    case "Interactable":
                        object_carabao.GetComponent<Interactable>().enabled = (bool) ParamData[2]["enabled"];
                        break;
                    case "Throwable":
                        object_carabao.GetComponent<Throwable>().enabled = (bool) ParamData[2]["enabled"];
                        break;
                    case "Haptics_Vive":
                        object_carabao.GetComponent<Haptics_Vive>().enabled = (bool) ParamData[2]["enabled"];
                        break;
                    case "Haptics_Pen_v1":
                        object_carabao.GetComponent<Haptics_Pen_v1>().enabled = (bool) ParamData[2]["enabled"];
                        break; 
                }
                break;
            case 2: // Stylus
                // condition on type of script
                switch(id) 
                {
                    case "SteamVR_TrackedObject": 
                        object_carabao.GetComponent<SteamVR_TrackedObject>().enabled = (bool) ParamData[1]["enabled"];
                        break;
                    case "Interactable":
                        object_carabao.GetComponent<Interactable>().enabled = (bool) ParamData[1]["enabled"];
                        break;
                    case "Throwable":
                        object_carabao.GetComponent<Throwable>().enabled = (bool) ParamData[1]["enabled"];
                        break;
                    case "Haptics_Vive":
                        object_carabao.GetComponent<Haptics_Vive>().enabled = (bool) ParamData[1]["enabled"];
                        break;
                    case "Haptics_Pen_v1":
                        object_carabao.GetComponent<Haptics_Pen_v1>().enabled = (bool) ParamData[1]["enabled"];
                        break; 
                }
                break;
            case 3: // Prop
                // condition on type of script
                switch(id) 
                {
                    case "SteamVR_TrackedObject": 
                        object_carabao.GetComponent<SteamVR_TrackedObject>().enabled = (bool) ParamData[0]["enabled"];
                        break;
                    case "Interactable":
                        object_carabao.GetComponent<Interactable>().enabled = (bool) ParamData[0]["enabled"];
                        break;
                    case "Throwable":
                        object_carabao.GetComponent<Throwable>().enabled = (bool) ParamData[0]["enabled"];
                        break;
                    case "Haptics_Vive":
                        object_carabao.GetComponent<Haptics_Vive>().enabled = (bool) ParamData[0]["enabled"];
                        break;
                    case "Haptics_Pen_v1":
                        object_carabao.GetComponent<Haptics_Pen_v1>().enabled = (bool) ParamData[0]["enabled"];
                        break; 
                }
                break;
        }
    }

    void StartCollider(string id, string params_JSON)
    {
        ParamData = JsonMapper.ToObject(params_JSON);
        GameObject collider = GameObject.Find(id);
        switch(device)  
        {
            // TODO: Write search function for indexing ParamData by device
            case 1: // VR-Controller
                collider.SetActive((bool) ParamData[2]["enabled"]);
                if ((bool) ParamData[2]["metrics"])    
                {
                    Vector3 position, rotation, scale;
                    position = new Vector3((float) ParamData[2]["metrics"]["transform"]["position"]["x"], (float) ParamData[2]["metrics"]["transform"]["position"]["y"], (float) ParamData[2]["metrics"]["transform"]["position"]["z"]);
                    rotation = new Vector3((float) ParamData[2]["metrics"]["transform"]["rotation"]["x"], (float) ParamData[2]["metrics"]["transform"]["rotation"]["y"], (float) ParamData[2]["metrics"]["transform"]["rotation"]["z"]);
                    scale = new Vector3((float) ParamData[2]["metrics"]["transform"]["scale"]["x"], (float) ParamData[2]["metrics"]["transform"]["scale"]["y"], (float) ParamData[2]["metrics"]["transform"]["scale"]["z"]);
                    if ((string) ParamData[2]["metrics"]["transform"]["origin"] == "relative")   
                    {
                        // Set everything using local transform variables
                        collider.transform.localPosition = position;
                        collider.transform.localRotation.x = rotation.x;
                        collider.transform.localRotation.y = rotation.y;
                        collider.transform.localRotation.z = rotation.z;
                        collider.transform.localScale = scale;
                    }
                    else
                    {
                        // Set everything using global transform variables
                        collider.transform.position = position;
                        collider.transform.rotation.x = rotation.x;
                        collider.transform.rotation.y = rotation.y;
                        collider.transform.rotation.z = rotation.z;
                        collider.transform.scale = scale;                        
                    }
                }
                break;
            case 2: // Stylus
                collider.SetActive((bool) ParamData[1]["enabled"]);
                if ((bool) ParamData[1]["metrics"])
                {
                    Vector3 position, rotation, scale;
                    position = new Vector3((float) ParamData[1]["metrics"]["transform"]["position"]["x"], (float) ParamData[1]["metrics"]["transform"]["position"]["y"], (float) ParamData[1]["metrics"]["transform"]["position"]["z"]);
                    rotation = new Vector3((float) ParamData[1]["metrics"]["transform"]["rotation"]["x"], (float) ParamData[1]["metrics"]["transform"]["rotation"]["y"], (float) ParamData[1]["metrics"]["transform"]["rotation"]["z"]);
                    scale = new Vector3((float) ParamData[1]["metrics"]["transform"]["scale"]["x"], (float) ParamData[1]["metrics"]["transform"]["scale"]["y"], (float) ParamData[1]["metrics"]["transform"]["scale"]["z"]);
                    if ((string) ParamData[1]["metrics"]["transform"]["origin"] == "relative")   
                    {
                        // Set everything using local transform variables
                        collider.transform.localPosition = position;
                        collider.transform.localRotation = rotation;
                        collider.transform.localScale = scale;
                    }   
                    else
                    {
                        // Set everything using global transform variables
                        collider.transform.position = position;
                        collider.transform.rotation = rotation;
                        collider.transform.scale = scale;                        
                    }                 
                }
                break;
            case 3: // Props
                collider.SetActive((bool) ParamData[0]["enabled"]);
                if ((bool) ParamData[0]["metrics"])
                {
                    Vector3 position, rotation, scale;
                    position = new Vector3((float) ParamData[0]["metrics"]["transform"]["position"]["x"], (float) ParamData[0]["metrics"]["transform"]["position"]["y"], (float) ParamData[0]["metrics"]["transform"]["position"]["z"]);
                    rotation = new Vector3((float) ParamData[0]["metrics"]["transform"]["rotation"]["x"], (float) ParamData[0]["metrics"]["transform"]["rotation"]["y"], (float) ParamData[0]["metrics"]["transform"]["rotation"]["z"]);
                    scale = new Vector3((float) ParamData[0]["metrics"]["transform"]["scale"]["x"], (float) ParamData[0]["metrics"]["transform"]["scale"]["y"], (float) ParamData[0]["metrics"]["transform"]["scale"]["z"]);
                    if ((string) ParamData[0]["metrics"]["transform"]["origin"] == "relative")   
                    {
                        // Set everything using local transform variables
                        collider.transform.localPosition = position;
                        collider.transform.localRotation = rotation;
                        collider.transform.localScale = scale;
                    } 
                    else
                    {
                        // Set everything using global transform variables
                        collider.transform.position = position;
                        collider.transform.rotation = rotation;
                        collider.transform.scale = scale;                        
                    }
                }
        }
    }

    void StartConstraint(string id, string params_JSON)
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
