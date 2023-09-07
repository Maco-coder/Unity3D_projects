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
    public static int device = OpeningScene_Devices.chosen_device;
    public int count_devices;

    public GameObject object_carabao;

    public string selected_device;

    void Start()
    {
        Debug.Log("ObjectManager running for " + object_carabao.name + " with device ID = " + device);
        JSONstring = File.ReadAllText("./Assets/Scripts/JSON/OBJECT_Haptic_style_sheet.json") ;
        FileData = JsonMapper.ToObject(JSONstring);
        // FileData has only 3 items, one for each device
        // We should select the device that we care about first, 
        // then make a second pass to disable stuff
        selected_device = (string) FileData[count_devices - device]["device"];
        List<JsonData> script_list = FileData[count_devices - device]["scripts"];
        List<JsonData> collider_list = FileData[count_devices - device]["colliders"];
        List<JsonData> constraint_list = FileData[count_devices - device]["constraints"];

        // 1. Parse all scripts
        foreach (JsonData script in script_list)
        {
            Debug.Log("ObjectManager for object " + object_carabao.name + " starting script with id " + script["id"]);
            StartScript(script);
        }

        // 2. Parse all colliders
        foreach (JsonData collider in collider_list)
        {
            Debug.Log("ObjectManager for object " + object_carabao.name + " starting collider with id " + collider["id"]);
            StartCollider(collider);
        }

        // 3. Parse all constraints
        foreach (JsonData constraint in constraint_list)
        {
            Debug.Log("ObjectManager for object " + object_carabao.name + " starting constraint with id " + constraint["id"]);
            StartConstraint(constraint);
        }
    } 

    void StartScript(JsonData script)
    {
        // 1. Set the enabled state of the script
        try
        {
            MonoBehaviour script = object_carabao.GetComponent(script["id"]) as MonoBehaviour;
            script.enabled = (bool) script["enabled"];
            Debug.Log("ObjectManager for object " + object_carabao.name + " successfully set " + script["id"] + " to " + (bool) script["enabled"]);
        }
        catch (Exception e)
        {
            Debug.LogError("ObjectManager for object " + object_carabao.name + " could not enable/disable the script " + script["id"]);
        }

        // 2. Set the metrics for the script, if provided
        try
        {
            // Create a dictionary for passing parameters to the script
            Dictionary<string, string> parameter_dictionary = new Dictionary<string, string>;
            Debug.Log("ObjectManager for object " + object_carabao.name + " created a parameter dictionary for script " + script["id"]);
            if ((bool) script["enabled"])
            {
                // Loop through the parameters in the metrics object
                var metrics_dictionary = script["metrics"];
                Debug.Log("ObjectManager for object " + object_carabao.name + " created dictionary object from the JSON files");
                foreach (var key in metrics_dictionary.Keys)
                {
                    Debug.Log("ObjectManager for object " + object_carabao.name + " setting parameter " + (string) key + " to " + (string) metrics_dictionary[key]);
                    parameter_dictionary.Add((string) key, (string) metrics_dictionary[key]);
                }
                // Attempt to pass the parameters to the script
                HMonoBehaviour script = object_carabao.GetComponent(script["id"]) as HMonoBehaviour;
                script.SetVariables(parameter_dictionary);
                Debug.Log("ObjectManager for object " + object_carabao.name + " set the parameters for script " + script["id"]);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("ObjectManager for object " + object_carabao.name + " failed to pass parameters for script " + script["id"]);
            Debug.LogError(e);
        }

    }

    void StartCollider(JsonData collider)
    {
        // 1. Set the enabled state of the collider
        GameObject colliderObject;
        try
        {
            colliderObject = transform.Find(collider["id"]).gameObject;
            Debug.Log("ObjectManager for object " + object_carabao.name + " found collider object named " + collider["id"]);
            colliderObject.SetActive((bool) collider["enabled"]);
        }
        catch (Exception e)
        {
            Debug.LogError("ObjectManager for object " + object_carabao.name + " failed to enable/disable the collider object named " + collider["id"]);
        }

        // 2. Set the position transform of the collider
        try
        {
            Vector3 position = new Vector3(float.Parse((string) collider["metrics"]["transform"]["position"]["x"]), float.Parse((string) collider["metrics"]["transform"]["position"]["y"]), float.Parse((string) collider["metrics"]["transform"]["position"]["z"]));
            if ((string) collider["metrics"]["transform"]["origin"] == "relative") colliderObject.transform.localPosition = position;
            if ((string) collider["metrics"]["transform"]["origin"] == "absolute") colliderObject.transform.position = position;
            Debug.Log("ObjectManager for object " + object_carabao.name + " successfully set position for collider with id: " + collider["id"]);
        }
        catch (Exception e)
        {
            Debug.LogError("ObjectManager for object " + object_carabao.name + " failed to set position for collider with id: " + collider["id"]);
        }

        // 3. Set the rotation transform of the collider
        try
        {
            Quaternion rotation = Quaternion.Euler(float.Parse((string) collider["metrics"]["transform"]["rotation"]["x"]), float.Parse((string) collider["metrics"]["transform"]["rotation"]["y"]), float.Parse((string) collider["metrics"]["transform"]["rotation"]["z"]));
            if ((string) collider["metrics"]["transform"]["origin"] == "relative") colliderObject.transform.localRotation = rotation;
            if ((string) collider["metrics"]["transform"]["origin"] == "absolute") colliderObject.transform.rotation = rotation;
            Debug.Log("ObjectManager for object " + object_carabao.name + " successfully set rotation for collider with id: " + collider["id"]);
        }
        catch (Exception e)
        {
            Debug.LogError("ObjectManager for object " + object_carabao.name + " failed to set rotation for collider with id: " + collider["id"]);
        }

        // 4. Set the scale transform of the collider
        try
        {
            Vector3 scale = new Vector3(float.Parse((string) collider["metrics"]["transform"]["scale"]["x"]), float.Parse((string) collider["metrics"]["transform"]["scale"]["y"]), float.Parse((string) collider["metrics"]["transform"]["scale"]["z"]));
            // Scale has only the local option
            colliderObject.transform.localScale = scale;
            Debug.Log("ObjectManager for object " + object_carabao.name + " successfully set scale for collider with id: " + collider["id"]);
        }
        catch (Exception e)
        {
            Debug.LogError("ObjectManager for object " + object_carabao.name + " failed to set scale for collider with id: " + collider["id"]);
        }

        // 5. If device == "stylus", set haptic feedback parameters if provided
        if (selected_device == "stylus")
        {
            try
            {
                // check for the type of effect being applied
                colliderObject.GetComponent<Collider_HapticPen>().feedback_choice = (string) collider["metrics"]["feedback-type"];
                switch((string) collider["metrics"]["feedback-type"])
                {
                    case "friction": 
                        // Friction parameters = {gain, magnitude}
                        try
                        {
                            colliderObject.GetComponent<Collider_HapticPen>().friction_gain = float.Parse((string) collider["metrics"]["gain"]);
                            colliderObject.GetComponent<Collider_HapticPen>().friction_magnitude = float.Parse((string) collider["metrics"]["magnitude"]);
                            Debug.Log("ObjectManager for object " + object_carabao.name + " successfully set friction feedback parameters for " + collider["id"]);
                        }
                        catch (Exception e)
                        {
                            Debug.LogError("ObjectManager for object " + object_carabao.name + " failed to set friction feedback parameters for " + collider["id"]);
                        }
                        break;
                    case "spring":
                        // Spring parameters = {gain, magnitude}
                        try
                        {
                            colliderObject.GetComponent<Collider_HapticPen>().spring_gain = float.Parse((string) collider["metrics"]["gain"]);
                            colliderObject.GetComponent<Collider_HapticPen>().spring_magnitude = float.Parse((string) collider["metrics"]["magnitude"]);
                            Debug.Log("ObjectManager for object " + object_carabao.name + " successfully set spring feedback parameters for " + collider["id"]);
                        }
                        catch (Exception e)
                        {
                            Debug.LogError("ObjectManager for object " + object_carabao.name + " failed to set spring feedback parameters for " + collider["id"]);
                        }
                        break;
                    case "vibrate":
                        // Vibration parameters = {gain, magnitude, direction_x, direction_y, direction_z}
                        try
                        {
                            colliderObject.GetComponent<Collider_HapticPen>().vibrate_gain = float.Parse((string) collider["metrics"]["gain"]);
                            colliderObject.GetComponent<Collider_HapticPen>().vibrate_magnitude = float.Parse((string) collider["metrics"]["magnitude"]);
                            colliderObject.GetComponent<Collider_HapticPen>().vibrate_direction_x = float.Parse((string) collider["metrics"]["direction"]["x"]);
                            colliderObject.GetComponent<Collider_HapticPen>().vibrate_direction_y = float.Parse((string) collider["metrics"]["direction"]["y"]);
                            colliderObject.GetComponent<Collider_HapticPen>().vibrate_direction_z = float.Parse((string) collider["metrics"]["direction"]["z"]);
                            Debug.Log("ObjectManager for object " + object_carabao.name + " successfully set vibration parameters for " + collider["id"])
                        }
                        catch (Exception e)
                        {
                            Debug.LogError("ObjectManager for object " + object_carabao.name + " failed to set vibration parameters for " + collider["id"]);
                        }
                        break;
                    case "viscous":
                        // Viscosity parameters = {gain, magnitude}
                        try
                        {
                            colliderObject.GetComponent<Collider_HapticPen>().viscous_gain = float.Parse((string) collider["metrics"]["gain"]);
                            colliderObject.GetComponent<Collider_HapticPen>().viscous_magnitude = float.Parse((string) collider["metrics"]["magnitude"]);
                            Debug.Log("ObjectManager for object " + object_carabao.name + " successfully set viscosity parameters for " + collider["id"]);
                        }
                        catch (Exception e)
                        {
                            Debug.LogError("ObjectManager for object " + object_carabao.name + " failed to set viscosity parameters for " + collider["id"]);
                        }
                        break;
                    case "constant":
                        // Constant parameters = {magnitude, direction_x, direction_y, direction_z}
                        try
                        {
                            colliderObject.GetComponent<Collider_HapticPen>().constant_magnitude = float.Parse((string) collider["metrics"]["magnitude"]);
                            colliderObject.GetComponent<Collider_HapticPen>().constant_direction_x = float.Parse((string) collider["metrics"]["direction"]["x"]);
                            colliderObject.GetComponent<Collider_HapticPen>().constant_direction_y = float.Parse((string) collider["metrics"]["direction"]["y"]);
                            colliderObject.GetComponent<Collider_HapticPen>().constant_direction_z = float.Parse((string) collider["metrics"]["direction"]["z"]);
                            Debug.Log("ObjectManager for object " + object_carabao.name + " successfully set constant haptic feedback parameters for " + collider["id"]);
                        }
                        catch (Exception e)
                        {
                            Debug.LogError("ObjectManager for object " + object_carabao.name + " failed to set constant haptic feedback parameters for " + collider["id"]);
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                Debug.LogError("ObjectManager for object " + object_carabao.name + " failed to find a valid configuration for haptic effects for collider with id: " + collider["id"]);
            }
        }

        // 6. If device == "vr_controller", set haptic feedback parameters if provided
        if (selected_device == "vr_controller")
        {
            try
            {
                colliderObject.GetComponent<Collider_HapticsVive>().amplitude = float.Parse((string) collider["metrics"]["amplitude"]);
                colliderObject.GetComponent<Collider_HapticsVive>().frequency = float.Parse((string) collider["metrics"]["frequency"]);
                Debug.Log("ObjectManager for object " + object_carabao.name + " successfully assigned amplitude, frequency for collider " + collider["id"]);
            }
            catch (Exception e)
            {
                Debug.LogError("ObjectManager for object " + object_carabao.name + " failed to find a valid configuration for haptic feedback for collider " + collider["id"]);
            }
        }
    }

    void StartConstraint(JsonData constraint)
    {
        if (! (bool) constraint["enabled"])
        {
            switch(constraint["id"])
            {
                case "SpringJoint":
                    GetComponent<SpringJoint>.spring = 0.0f;
                    GetComponent<SpringJoint>.damper = 0.0f;
                    GetComponent<SpringJoint>.breakTorque = 0.0f;
                    GetComponent<SpringJoint>.breakForce = 0.0f;
                    Debug.Log("ObjectManager for object " + object_carabao.name + " disabled SpringJoint");
                    break;
            }
            return;
        }
        try
        {
            switch ((string) constraint["metrics"]["constraint-type"])
            {
                case "SpringJoint":
                    GetComponent<SpringJoint>().spring = float.Parse((string) constraint["metrics"]["spring"]);
                    GetComponent<SpringJoint>().damper = float.Parse((string) constraint["metrics"]["damper"]);
                    GetComponent<SpringJoint>().breakTorque = float.Parse((string) constraint["metrics"]["breakTorque"]);
                    GetComponent<SpringJoint>().breakForce = float.Parse((string) constraint["metrics"]["breakForce"]);
                    Debug.Log("ObjectManager for object " + object_carabao.name + " successfully set SpringJoint parameters");
                    break;
            }
        }
        catch (Exception e)
        {
            Debug.Log("ObjectManager for object " + object_carabao.name + " encountered an error while initializing constraint with id: " + constraint["id"]);
        }
    }

}
