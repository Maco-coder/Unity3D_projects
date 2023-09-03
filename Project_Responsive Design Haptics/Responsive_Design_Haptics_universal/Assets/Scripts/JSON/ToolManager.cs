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
        Debug.Log("ToolManager running for " + object_carabao.name + " with device ID = " + device);
        JSONstring = File.ReadAllText("./Assets/Scripts/JSON/Haptic_style_sheet_v1.json") ;
        FileData = JsonMapper.ToObject(JSONstring);
        for (int i = 0; i < FileData.Count; i++)    {
            string id = (string) FileData[i]["id"];
            string type = (string) FileData[i]["type"];
            string class_JSON = (string) FileData[i]["class"];
            List<JsonData> params_JSON = new List<JsonData>();
            for (int j = 0; j < count_devices; j++) {
                JsonData param = FileData[i]["params"][j];
                params_JSON.Add(param);
            }
            // This is for tool-related JSON data
            if (class_JSON == "tool")   {
                switch (type) {
                    case "script":
                        Debug.Log("Manager for object: " + object_carabao.name + " processing script: " + id);
                        StartScript(id, params_JSON);
                        break;
                    case "collider":
                        Debug.Log("Manager for object: " + object_carabao.name + " processing collider: " + id);
                        StartCollider(id, params_JSON);
                        break;
                    case "constraint":
                        Debug.Log("Manager for object: " + object_carabao.name + " processing constraint: " + id);
                        StartConstraint(id, params_JSON); 
                        break;
                }
            }
        }
        // NEED TO ADD TO GRAMMAR
        if ((device == 2 || device == 3) && object_carabao.name == "Picker")
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Rigidbody>().useGravity = false;
        }
    } 

    void StartScript(string id, List<JsonData> params_JSON)   
    {
        ParamData = params_JSON[count_devices - device];
        
        // 1. Enable/Disable script as specified in the file
        try
        {
            MonoBehaviour script = object_carabao.GetComponent(id) as MonoBehaviour;
            script.enabled = (bool) ParamData["enabled"];
            Debug.Log("Manager for object " + object_carabao.name + " set " + id + " to " + (bool) ParamData["enabled"]);
        }
        catch (Exception e)
        {
            Debug.Log("Manager for object " + object_carabao.name + " could not use the GetComponent(string) function for " + id); 
        }

        // 2. Assign parameters for enabled scripts
        try
        {
            // Create a dictionary for passing parameters to the script
            Dictionary<string, string> variable_dictionary = new Dictionary<string, string>();
            Debug.Log("Manager for object " + object_carabao.name + " created a dictionary for the script " + id);
            if ((bool) ParamData["enabled"])
            {
                // Loop through the parameters in the metrics object
                var metrics_dictionary = ParamData["metrics"];
                Debug.Log("Manager for object " + object_carabao.name + " created dict object from JSON with type " + typeof(metrics_dictionary));
                foreach(var key in metrics_dictionary.Keys)
                {
                    Debug.Log("Manager for object " + object_carabao.name + " setting parameter " + (string) key + " to " + (string) metrics_dictionary[key]);
                    variable_dictionary.Add((string) key, (string) metrics_dictionary[key]);
                }
                // Attempt to pass the parameters to the script
                HMonoBehaviour script = object_carabao.GetComponent(id) as HMonoBehaviour;
                script.SetVariables(variable_dictionary);
            }
        }
        catch (Exception e)
        {
            Debug.Log("Manager for object " + object_carabao.name + " failed to pass parameters for the script " + id);
            Debug.LogError(e);
        }
    }

    void StartCollider(string id, List<JsonData> params_JSON)
    {
        ParamData = params_JSON[count_devices - device];
        try
        {
            GameObject collider = transform.Find(id).gameObject;
            Debug.Log("Manager for object " + object_carabao.name + " found collider object named " + collider.name);
            Vector3 position, scale;
            Quaternion rotation;
            collider.SetActive((bool) ParamData["enabled"]);

            // 1. Start by trying to set the position component of the collider
            try
            {
                position = new Vector3(float.Parse((string) ParamData["metrics"]["transform"]["position"]["x"]), float.Parse((string) ParamData["metrics"]["transform"]["position"]["y"]), float.Parse((string) ParamData["metrics"]["transform"]["position"]["z"]));
                if ((string) ParamData["metrics"]["transform"]["origin"] == "relative") collider.transform.localPosition = position;
                if ((string) ParamData["metrics"]["transform"]["origin"] == "absolute") collider.transform.position = position;
                Debug.Log("Manager for object " + object_carabao.name + " successfully set position for collider with id: " + id);
            }   
            catch (Exception ex)
            {
                Debug.Log("Manager for object " + object_carabao.name + " could not set the position for collider with id: " + id);
            }

            // 2. Set the rotation of the collider
            try
            {
                rotation = Quaternion.Euler(float.Parse((string) ParamData["metrics"]["transform"]["rotation"]["x"]), float.Parse((string) ParamData["metrics"]["transform"]["rotation"]["y"]), float.Parse((string) ParamData["metrics"]["transform"]["rotation"]["z"]));
                if ((string) ParamData["metrics"]["transform"]["origin"] == "relative") collider.transform.localRotation = rotation;
                if ((string) ParamData["metrics"]["transform"]["origin"] == "absolute") collider.transform.rotation = rotation;
                Debug.Log("Manager for object " + object_carabao.name + " successfully set rotation for collider with id: " + id);
            }
            catch (Exception ex)
            {
                Debug.Log("Manager for object " + object_carabao.name + " could not set the rotation for collider with id: " + id);
            } 

            // 3. Set the scale of the collider
            try
            {
                scale = new Vector3(float.Parse((string) ParamData["metrics"]["transform"]["scale"]["x"]), float.Parse((string) ParamData["metrics"]["transform"]["scale"]["y"]), float.Parse((string) ParamData["metrics"]["transform"]["scale"]["z"]));
                collider.transform.localScale = scale; // Scale is always locally specified in Unity
                Debug.Log("Manager for object " + object_carabao.name + " successfully set scale for collider with id: " + id);
            }
            catch (Exception ex)
            {
                Debug.Log("Manager for object " + object_carabao.name + " could not set the scale for collider with id: " + id);
            }

            // 4. Set the parameters for haptic effects (in the case of force-feedback devices)
            if ((string) ParamData["device"] == "stylus")
            {
                try
                {
                    // Check for the type of feedback that is being applied 
                    collider.GetComponent<Collider_HapticPen>().feedback_choice = (string) ParamData["metrics"]["feedback-type"];
                    switch((string) ParamData["metrics"]["feedback-type"])
                    {
                        case "friction": 
                            // Friction parameters = {gain, magnitude}
                            try
                            {
                                collider.GetComponent<Collider_HapticPen>().friction_gain = float.Parse((string) ParamData["metrics"]["gain"]);
                                collider.GetComponent<Collider_HapticPen>().friction_magnitude = float.Parse((string) ParamData["metrics"]["magnitude"]);
                                Debug.Log("Manager for object " + object_carabao.name + " successfully set friction parameters for collider with id: " + id);
                            }
                            catch (Exception ex)
                            {
                                Debug.Log("Manager for object " + object_carabao.name + " could not set the friction parameters for collider with id: " + id);
                            }
                            break;
                        case "spring":
                            // Spring parameters = {gain, magnitude}
                            try
                            {
                                collider.GetComponent<Collider_HapticPen>().spring_gain = float.Parse((string) ParamData["metrics"]["gain"]);
                                collider.GetComponent<Collider_HapticPen>().spring_magnitude = float.Parse((string) ParamData["metrics"]["magnitude"]);
                                Debug.Log("Manager for object " + object_carabao.name + " successfully set spring parameters for collider with id: " + id);
                            }
                            catch (Exception ex)
                            {
                                Debug.Log("Manager for object " + object_carabao.name + " could not set the spring parameters for collider with id: " + id);
                            }
                            break;
                        case "vibrate":
                            // Vibration parameters = {gain, magnitude, direction_x, direction_y, direction_z}
                            try
                            {
                                collider.GetComponent<Collider_HapticPen>().vibrate_gain = float.Parse((string) ParamData["metrics"]["gain"]);
                                collider.GetComponent<Collider_HapticPen>().vibrate_magnitude = float.Parse((string) ParamData["metrics"]["magnitude"]);
                                collider.GetComponent<Collider_HapticPen>().vibrate_direction_x = float.Parse((string) ParamData["metrics"]["direction"]["x"]);
                                collider.GetComponent<Collider_HapticPen>().vibrate_direction_y = float.Parse((string) ParamData["metrics"]["direction"]["y"]);
                                collider.GetComponent<Collider_HapticPen>().vibrate_direction_z = float.Parse((string) ParamData["metrics"]["direction"]["z"]);
                                Debug.Log("Manager for object " + object_carabao.name + " successfully set vibration parameters for collider with id: " + id);
                            }
                            catch (Exception ex)
                            {
                                Debug.Log("Manager for object " + object_carabao.name + " could not set the vibration parameters for collider with id: " + id);
                            }
                            break;
                        case "viscous":
                            // Viscosity parameters = {gain, magnitude}
                            try
                            {
                                collider.GetComponent<Collider_HapticPen>().viscous_gain = float.Parse((string) ParamData["metrics"]["gain"]);
                                collider.GetComponent<Collider_HapticPen>().viscous_magnitude = float.Parse((string) ParamData["metrics"]["magnitude"]);
                                Debug.Log("Manager for object " + object_carabao.name + " successfully set viscosity parameters for collider with id: " + id);
                            }
                            catch (Exception ex)
                            {
                                Debug.Log("Manager for object " + object_carabao.name + " could not set the viscosity parameters for collider with id: " + id);
                            }
                            break;
                        case "constant":
                            // Constant parameters = {magnitude, direction_x, direction_y, direction_z}
                            try
                            {
                                collider.GetComponent<Collider_HapticPen>().constant_magnitude = float.Parse((string) ParamData["metrics"]["magnitude"]);
                                collider.GetComponent<Collider_HapticPen>().constant_direction_x = float.Parse((string) ParamData["metrics"]["direction"]["x"]);
                                collider.GetComponent<Collider_HapticPen>().constant_direction_y = float.Parse((string) ParamData["metrics"]["direction"]["y"]);
                                collider.GetComponent<Collider_HapticPen>().constant_direction_z = float.Parse((string) ParamData["metrics"]["direction"]["z"]);
                                Debug.Log("Manager for object " + object_carabao.name + " successfully set constant parameters for collider with id: " + id);
                            }
                            catch (Exception ex)
                            {
                                Debug.Log("Manager for object " + object_carabao.name + " could not set the constant force parameters for collider with id: " + id);
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // In case the manager does not find a valid feedback-type field
                    Debug.Log("Manager for object " + object_carabao.name + " could not find a valid configuration for haptic effects for collider with id: " + id);
                }
            }

            // Set the parameters for haptic effects (in the case of VR-Controller devices)
            if ((string) ParamData["device"] == "vr_controller")
            {
                try
                {
                    // Vibrotactile feedback only cares about amplitude, frequency (and duration, if we want to specify that here)
                    collider.GetComponent<Collider_HapticsVive>().amplitude = float.Parse((string) ParamData["metrics"]["amplitude"]);
                    collider.GetComponent<Collider_HapticsVive>().frequency = float.Parse((string) ParamData["metrics"]["frequency"]);
                    Debug.Log("Manager for object " + object_carabao.name + " successfully assigned amplitude, frequency parameters for collider with id: " + id);
                }
                catch (Exception e)
                {
                    // In case the manager does not find a valid feedback-type field
                    Debug.Log("Manager for object " + object_carabao.name + " could not find a valid configuration for haptic effects for collider with id: " + id);
                }
            }
        }
        catch (Exception ex)
        {
            // In case the manager fails to find the collider object
            Debug.Log("Manager for object " + object_carabao.name + " could not find collider with id: " + id);
        }
    }

    void StartConstraint(string id, List<JsonData> params_JSON)
    {
        ParamData = params_JSON[count_devices - device];

        // Check if the constraint is supposed to be enabled in the first place
        if (! (bool) ParamData["enabled"])
        {
            // If not, then set all constraint parameters to zero to disable the constraint
            switch(id)
            {
                case "SpringJoint":
                    GetComponent<SpringJoint>().spring = 0.0f;
                    GetComponent<SpringJoint>().damper = 0.0f;
                    GetComponent<SpringJoint>().breakTorque = 0.0f;
                    GetComponent<SpringJoint>().breakForce = 0.0f;
                    break;
            }
            return;
        }
        try
        {
            // If the constraint is enabled, it should specify the parameters to be set 
            switch((string) ParamData["metrics"]["constraint-type"])
            {
                case "SpringJoint":
                    GetComponent<SpringJoint>().spring = float.Parse((string) ParamData["metrics"]["spring"]);
                    GetComponent<SpringJoint>().damper = float.Parse((string) ParamData["metrics"]["damper"]);
                    GetComponent<SpringJoint>().breakTorque = float.Parse((string) ParamData["metrics"]["breakTorque"]);
                    GetComponent<SpringJoint>().breakForce = float.Parse((string) ParamData["metrics"]["breakForce"]);
                    Debug.Log("Manager for object " + object_carabao.name + " successfully set constraint parameters for constraint with id: " + id);
                    break;
            }
        }
        catch(Exception ex)
        {
            // In case the constraint parameters are missing/incomplete
            Debug.Log("Manager for object " + object_carabao.name + " encountered an error while initializing constraint with id: " + id);
            return;
        }
    }
}
