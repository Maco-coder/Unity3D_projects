
// HAPTICS_VIVE //

using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;
using System.IO                 ;
using System                    ;
using Valve.VR                  ;


public class Haptics_Vive : HMonoBehaviour
{

    public GameObject cube_in_tree ;
    public GameObject apple_in_tree;

    public SteamVR_Action_Single squeezeAction   ;
    public SteamVR_Action_Vibration hapticAction ;

    bool isCurrentlyCollidingWTree  ;
    bool isCurrentlyCollidingWApple ;
    bool isCurrentlyCollidingWBox   ;

    public bool isSet = false;


    void SetVariables(Dictionary<string, string> variable_dictionary)
    {
        Debug.Log("Haptics_Vive SetVariables() is running...");
        foreach(var item in variable_dictionary)
        {
            Debug.Log("Haptics_Vive SetVariables() is setting the field " + item.Key + " to the value " + item.Value);
            switch(item.Key)
            {
                case "CarryApple_amplitude":
                    GetComponent<Collider_HapticsVive>().CarryApple_amplitude = float.Parse((string) item.Value);
                    break;
                case "CarryApple_frequency":
                    GetComponent<Collider_HapticsVive>().CarryApple_frequency = float.Parse((string) item.Value);
                    break;
                case "PluckApple_amplitude":
                    GetComponent<Collider_HapticsVive>().PluckApple_amplitude = float.Parse((string) item.Value);
                    break;
                case "PluckApple_frequency":
                    GetComponent<Collider_HapticsVive>().PluckApple_frequency = float.Parse((string) item.Value);
                    break;
                default:
                    break;
            }
        }
        isSet = true;
    }

    void Update()
    {
        float distance_apple_tree = Vector3.Distance(cube_in_tree.transform.position, apple_in_tree.transform.position);
        Debug.Log(distance_apple_tree.ToString());

        float triggerValueL = squeezeAction.GetAxis(SteamVR_Input_Sources.LeftHand)  ;
        float triggerValueR = squeezeAction.GetAxis(SteamVR_Input_Sources.RightHand) ;


        if ( (distance_apple_tree > 0.17) && (distance_apple_tree < 0.3) && (triggerValueR > 0.0f) )
        {
            Debug.Log(distance_apple_tree.ToString()) ;
            Pulse(1, gameObject.GetComponent<Collider_HapticsVive>().PluckApple_amplitude, distance_apple_tree*gameObject.GetComponent<Collider_HapticsVive>().PluckApple_frequency, SteamVR_Input_Sources.RightHand) ;
        }

    }


    private void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        hapticAction.Execute(0, duration, frequency, amplitude, source);
        print("Pulse" + "" + source.ToString());
    }


    void OnCollisionEnter(Collision collision){

        if (collision.gameObject.name == "TREE"){
            isCurrentlyCollidingWTree = true ;
        }

        if (collision.gameObject.name == "OuterCubeInTree")
            Pulse(0.2f, collision.gameObject.GetComponent<Collider_HapticsVive>().amplitude, collision.gameObject.GetComponent<Collider_HapticsVive>().frequency, SteamVR_Input_Sources.RightHand);


        if (collision.gameObject.name == "TrunkCubeInTree")
            Pulse(0.5f, collision.gameObject.GetComponent<Collider_HapticsVive>().amplitude, collision.gameObject.GetComponent<Collider_HapticsVive>().frequency, SteamVR_Input_Sources.RightHand);


        float triggerValueR = squeezeAction.GetAxis(SteamVR_Input_Sources.RightHand);
        float distance_apple_tree = Vector3.Distance(cube_in_tree.transform.position, apple_in_tree.transform.position);


        if ( (collision.gameObject.name == "Apple") && (distance_apple_tree > 0.22) && (triggerValueR > 0.0f))
        {
            Debug.Log(distance_apple_tree.ToString());
            Pulse(0.2f, gameObject.GetComponent<Collider_HapticsVive>().CarryApple_amplitude, gameObject.GetComponent<Collider_HapticsVive>().CarryApple_frequency, SteamVR_Input_Sources.RightHand);
        }


    }


    void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.name == "InnerCubeInTree")
            Pulse(1, collision.gameObject.GetComponent<Collider_HapticsVive>().amplitude, collision.gameObject.GetComponent<Collider_HapticsVive>().frequency, SteamVR_Input_Sources.RightHand) ;

    }


    void OnCollisionExit(Collision collision){

        isCurrentlyCollidingWTree = false  ;

    }

}