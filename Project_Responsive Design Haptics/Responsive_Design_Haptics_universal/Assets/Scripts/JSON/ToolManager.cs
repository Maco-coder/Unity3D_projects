using System.Collections        ;
using UnityEngine;
using System.Collections.Generic;
using System.IO                 ;
using LitJson                   ;
using System;
using Valve.VR                   ; // Needed to enable and disable VR trackers //
using Valve.VR.InteractionSystem ; // Needed to enable and disable VR controllers //


public class ToolManager : MonoBehaviour 
{
    private string JSONstring;
    private JsonData FileData;
    private JsonData ParamData;
    public static int device = OpeningScene_Devices.chosen_device;
    public int count_devices;

    public GameObject object_carabao;

    void Start()
    {
        Debug.Log("ToolManager running for " + object_carabao);
        JSONstring = File.ReadAllText("./Assets/Scripts/JSON/Haptic_style_sheet_v1.jsonc") ;
        FileData = JsonMapper.ToObject(JSONstring);
        for (int i = 0; i < FileData.Count; i++)    {
            string id = (string) FileData[i]["id"];
            string type = (string) FileData[i]["type"];
            string class_JSON = (string) FileData[i]["class"];
            // string params_JSON = (string) FileData[i]["params"];
            List<string> params_JSON = new List<string>;
            for (int j = 0; j < count_devices; j++) {
                string param = (string) FileData[i]["params"][j];
                params_JSON.Add(param);
            }
            // This is for tool-related JSON data
            if (class_JSON == "tool")   {
                switch (type) {
                case "script":
                    if (object_carabao.transform.Find(id)) 
                        StartScript(id, params_JSON);
                    break;
                case "collider":
                    if (object_carabao.transform.Find(id)) 
                        StartCollider(id, params_JSON);
                    break;
                case "constraint":
                    if (object_carabao.transform.Find(id)) 
                        StartConstraint(id, params_JSON);
                    break;
                }
            }
        }
    } 

    void StartScript(string id, List<string> params_JSON)   
    {
        ParamData = JsonMapper.ToObject(params_JSON[3 - device]);
        switch(device)
        {
            // TODO: Write search function for indexing ParamData by device
            case 1: // VR-Controller
                // condition on type of script
                switch(id) 
                {
                    case "SteamVR_TrackedObject": 
                        Debug.Log("Value of enabled for SteamVR_TrackedObject: " + (bool) ParamData["enabled"]);
                        object_carabao.GetComponent<SteamVR_TrackedObject>().enabled = (bool) ParamData["enabled"];
                        break;
                    case "Interactable":
                        object_carabao.GetComponent<Interactable>().enabled = (bool) ParamData["enabled"];
                        break;
                    case "Throwable":
                        object_carabao.GetComponent<Throwable>().enabled = (bool) ParamData["enabled"];
                        break;
                    case "Haptics_Vive":
                        object_carabao.GetComponent<Haptics_Vive>().enabled = (bool) ParamData["enabled"];
                        break;
                    case "Haptics_Pen_v1":
                        Debug.Log("Value of enabled for Haptics_Pen_v1: " + (bool) ParamData["enabled"]);
                        object_carabao.GetComponent<Haptics_Pen_v1>().enabled = (bool) ParamData["enabled"];
                        break; 
                }
                break;
            case 2: // Stylus
                // condition on type of script
                switch(id) 
                {
                    case "SteamVR_TrackedObject": 
                        object_carabao.GetComponent<SteamVR_TrackedObject>().enabled = (bool) ParamData["enabled"];
                        break;
                    case "Interactable":
                        object_carabao.GetComponent<Interactable>().enabled = (bool) ParamData["enabled"];
                        break;
                    case "Throwable":
                        object_carabao.GetComponent<Throwable>().enabled = (bool) ParamData["enabled"];
                        break;
                    case "Haptics_Vive":
                        object_carabao.GetComponent<Haptics_Vive>().enabled = (bool) ParamData["enabled"];
                        break;
                    case "Haptics_Pen_v1":
                        object_carabao.GetComponent<Haptics_Pen_v1>().enabled = (bool) ParamData["enabled"];
                        break; 
                }
                break;
            case 3: // Prop
                // condition on type of script
                switch(id) 
                {
                    case "SteamVR_TrackedObject": 
                        object_carabao.GetComponent<SteamVR_TrackedObject>().enabled = (bool) ParamData["enabled"];
                        break;
                    case "Interactable":
                        object_carabao.GetComponent<Interactable>().enabled = (bool) ParamData["enabled"];
                        break;
                    case "Throwable":
                        object_carabao.GetComponent<Throwable>().enabled = (bool) ParamData["enabled"];
                        break;
                    case "Haptics_Vive":
                        object_carabao.GetComponent<Haptics_Vive>().enabled = (bool) ParamData["enabled"];
                        break;
                    case "Haptics_Pen_v1":
                        object_carabao.GetComponent<Haptics_Pen_v1>().enabled = (bool) ParamData["enabled"];
                        break; 
                }
                break;
        }
    }

    void StartCollider(string id, List<string> params_JSON)
    {
        ParamData = JsonMapper.ToObject(params_JSON[3 - device]);
        GameObject collider = GameObject.Find(id);
        Vector3 position, scale;
        Quaternion rotation;
        switch(device)  
        {
            // TODO: Write search function for indexing ParamData by device
            case 1: // VR-Controller
                collider.SetActive((bool) ParamData["enabled"]);
                if ((bool) ParamData["metrics"])    
                {
                    position = new Vector3((float) ParamData["metrics"]["transform"]["position"]["x"], (float) ParamData["metrics"]["transform"]["position"]["y"], (float) ParamData["metrics"]["transform"]["position"]["z"]);
                    rotation = Quaternion.Euler((float) ParamData["metrics"]["transform"]["rotation"]["x"], (float) ParamData["metrics"]["transform"]["rotation"]["y"], (float) ParamData["metrics"]["transform"]["rotation"]["z"]);
                    scale = new Vector3((float) ParamData["metrics"]["transform"]["scale"]["x"], (float) ParamData["metrics"]["transform"]["scale"]["y"], (float) ParamData["metrics"]["transform"]["scale"]["z"]);
                    if ((string) ParamData["metrics"]["transform"]["origin"] == "relative")   
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
                        collider.transform.localScale = scale;                        
                    }
                }
                break;
            case 2: // Stylus
                collider.SetActive((bool) ParamData["enabled"]);
                if ((bool) ParamData["metrics"])
                {
                    position = new Vector3((float) ParamData["metrics"]["transform"]["position"]["x"], (float) ParamData["metrics"]["transform"]["position"]["y"], (float) ParamData["metrics"]["transform"]["position"]["z"]);
                    rotation = Quaternion.Euler((float) ParamData["metrics"]["transform"]["rotation"]["x"], (float) ParamData["metrics"]["transform"]["rotation"]["y"], (float) ParamData["metrics"]["transform"]["rotation"]["z"]);
                    scale = new Vector3((float) ParamData["metrics"]["transform"]["scale"]["x"], (float) ParamData["metrics"]["transform"]["scale"]["y"], (float) ParamData["metrics"]["transform"]["scale"]["z"]);
                    if ((string) ParamData["metrics"]["transform"]["origin"] == "relative")   
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
                        collider.transform.localScale = scale;                        
                    }                 
                }
                break;
            case 3: // Props
                collider.SetActive((bool) ParamData["enabled"]);
                if ((bool) ParamData["metrics"])
                {
                    position = new Vector3((float) ParamData["metrics"]["transform"]["position"]["x"], (float) ParamData["metrics"]["transform"]["position"]["y"], (float) ParamData["metrics"]["transform"]["position"]["z"]);
                    rotation = Quaternion.Euler((float) ParamData["metrics"]["transform"]["rotation"]["x"], (float) ParamData["metrics"]["transform"]["rotation"]["y"], (float) ParamData["metrics"]["transform"]["rotation"]["z"]);
                    scale = new Vector3((float) ParamData["metrics"]["transform"]["scale"]["x"], (float) ParamData["metrics"]["transform"]["scale"]["y"], (float) ParamData["metrics"]["transform"]["scale"]["z"]);
                    if ((string) ParamData["metrics"]["transform"]["origin"] == "relative")   
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
                        collider.transform.localScale = scale;                        
                    }
                }
                break;
        }
    }

    void StartConstraint(string id, List<string> params_JSON)
    {
        ParamData = JsonMapper.ToObject(params_JSON[3 - device]);
        switch(device)
        {
            case 1: // VR-Controller
                switch((string) ParamData["metrics"]["constraint-type"])
                {
                    case "SpringJoint":
                        //GetComponent<SpringJoint>().SetActive((bool) ParamData[2]["enabled"]);
                        if ((bool) ParamData["metrics"])
                        {
                            GetComponent<SpringJoint>().spring = (float) ParamData["metrics"]["spring"];
                            GetComponent<SpringJoint>().damper = (float) ParamData["metrics"]["damper"];
                            GetComponent<SpringJoint>().breakTorque = (float) ParamData["metrics"]["breakTorque"];
                            GetComponent<SpringJoint>().breakForce = (float) ParamData["metrics"]["breakForce"];
                        } 
                        else
                        {
                            GetComponent<SpringJoint>().spring = 0.0f;
                            GetComponent<SpringJoint>().damper = 0.0f;
                            GetComponent<SpringJoint>().breakTorque = 0.0f;
                            GetComponent<SpringJoint>().breakForce = 0.0f;
                        }
                        break;
                }
                break;
            case 2: // Stylus
                switch((string) ParamData["metrics"]["constraint-type"])
                {
                    case "SpringJoint":
                        //GetComponent<SpringJoint>().SetActive((bool) ParamData[1]["enabled"]);
                        if ((bool) ParamData["metrics"])
                        {
                            GetComponent<SpringJoint>().spring = (float) ParamData["metrics"]["spring"];
                            GetComponent<SpringJoint>().damper = (float) ParamData["metrics"]["damper"];
                            GetComponent<SpringJoint>().breakTorque = (float) ParamData["metrics"]["breakTorque"];
                            GetComponent<SpringJoint>().breakForce = (float) ParamData["metrics"]["breakForce"];
                        }
                        else
                        {
                            GetComponent<SpringJoint>().spring = 0.0f;
                            GetComponent<SpringJoint>().damper = 0.0f;
                            GetComponent<SpringJoint>().breakTorque = 0.0f;
                            GetComponent<SpringJoint>().breakForce = 0.0f;
                        }
                        break;
                }
                break;
            case 3: // Props
                switch((string) ParamData["metrics"]["constraint-type"])
                {
                    case "SpringJoint":
                        //GetComponent<SpringJoint>().SetActive((bool) ParamData[0]["enabled"]);
                        if ((bool) ParamData["metrics"])
                        {
                            GetComponent<SpringJoint>().spring = (float) ParamData["metrics"]["spring"];
                            GetComponent<SpringJoint>().damper = (float) ParamData["metrics"]["damper"];
                            GetComponent<SpringJoint>().breakTorque = (float) ParamData["metrics"]["breakTorque"];
                            GetComponent<SpringJoint>().breakForce = (float) ParamData["metrics"]["breakForce"];
                        }
                        else
                        {
                            GetComponent<SpringJoint>().spring = 0.0f;
                            GetComponent<SpringJoint>().damper = 0.0f;
                            GetComponent<SpringJoint>().breakTorque = 0.0f;
                            GetComponent<SpringJoint>().breakForce = 0.0f;
                        }
                        break;
                }
                break;
        }
    }
}
