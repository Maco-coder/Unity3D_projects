
// HAPTICS_VIVE //

using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;
using Valve.VR                  ;


public class Haptics_Vive : MonoBehaviour
{

    public GameObject cube_in_tree ;
    public GameObject apple_in_tree;

    public SteamVR_Action_Single squeezeAction   ;
    public SteamVR_Action_Vibration hapticAction ;

    bool isCurrentlyCollidingWTree  ;
    bool isCurrentlyCollidingWApple ;
    bool isCurrentlyCollidingWBox   ;

    public float OuterCubeInTree_amplitude ;
    public float OuterCubeInTree_frequency ;

    public float InnerCubeInTree_amplitude ;
    public float InnerCubeInTree_frequency ;

    public float TrunkCubeInTree_amplitude ;
    public float TrunkCubeInTree_frequency ;

    public float PluckApple_amplitude        ;
    public float PluckApple_frequency_factor ;

    public float CarryApple_amplitude ;
    public float CarryApple_frequency ;




    void Update()
    {
        float distance_apple_tree = Vector3.Distance(cube_in_tree.transform.position, apple_in_tree.transform.position);
        Debug.Log(distance_apple_tree.ToString());

        float triggerValueL = squeezeAction.GetAxis(SteamVR_Input_Sources.LeftHand)  ;
        float triggerValueR = squeezeAction.GetAxis(SteamVR_Input_Sources.RightHand) ;


        if ( (distance_apple_tree > 0.17) && (distance_apple_tree < 0.3) && (triggerValueR > 0.0f) )
        {
            Debug.Log(distance_apple_tree.ToString())                              ;
            Pulse(1, PluckApple_amplitude, distance_apple_tree*PluckApple_frequency_factor, SteamVR_Input_Sources.RightHand) ;
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
            Pulse(0.2f, OuterCubeInTree_amplitude, OuterCubeInTree_frequency, SteamVR_Input_Sources.RightHand);


        if (collision.gameObject.name == "TrunkCubeInTree")
            Pulse(0.5f, TrunkCubeInTree_amplitude, TrunkCubeInTree_frequency, SteamVR_Input_Sources.RightHand);


        float triggerValueR = squeezeAction.GetAxis(SteamVR_Input_Sources.RightHand);
        float distance_apple_tree = Vector3.Distance(cube_in_tree.transform.position, apple_in_tree.transform.position);


        if ( (collision.gameObject.name == "Apple") && (distance_apple_tree > 0.22) && (triggerValueR > 0.0f))
        {
            Debug.Log(distance_apple_tree.ToString());
            Pulse(0.2f, CarryApple_amplitude, CarryApple_frequency, SteamVR_Input_Sources.RightHand);
        }


    }


    void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.name == "InnerCubeInTree")
            Pulse(1, InnerCubeInTree_amplitude, InnerCubeInTree_frequency, SteamVR_Input_Sources.RightHand) ;

    }


    void OnCollisionExit(Collision collision){

        isCurrentlyCollidingWTree = false  ;

    }


}