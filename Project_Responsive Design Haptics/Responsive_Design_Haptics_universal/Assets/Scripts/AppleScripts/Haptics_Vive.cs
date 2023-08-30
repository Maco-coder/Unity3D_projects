
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


    void Update()
    {
        float distance_apple_tree = Vector3.Distance(cube_in_tree.transform.position, apple_in_tree.transform.position);
        Debug.Log(distance_apple_tree.ToString());

        float triggerValueL = squeezeAction.GetAxis(SteamVR_Input_Sources.LeftHand)  ;
        float triggerValueR = squeezeAction.GetAxis(SteamVR_Input_Sources.RightHand) ;


        if ( (distance_apple_tree > 0.17) && (distance_apple_tree < 0.3) && (triggerValueR > 0.0f) )
        {
            Debug.Log(distance_apple_tree.ToString())                              ;
            Pulse(1, 50, distance_apple_tree*500, SteamVR_Input_Sources.RightHand) ;
        }

    }


    private void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        hapticAction.Execute(0, duration, frequency, amplitude, source);
        print("Pulse" + "" + source.ToString());
    }


    void OnCollisionEnter(Collision collision){

        if (collision.gameObject.name == "TREE-general"){
            isCurrentlyCollidingWTree = true ;
        }

        if (collision.gameObject.name == "OuterCube_InTree")
            Pulse(0.2f, 1, 200, SteamVR_Input_Sources.RightHand);


        if (collision.gameObject.name == "TrunkCube_InTree")
            Pulse(0.5f, 1, 300, SteamVR_Input_Sources.RightHand);


        float triggerValueR = squeezeAction.GetAxis(SteamVR_Input_Sources.RightHand);
        float distance_apple_tree = Vector3.Distance(cube_in_tree.transform.position, apple_in_tree.transform.position);


        if ( (collision.gameObject.name == "Apple") && (distance_apple_tree > 0.22) && (triggerValueR > 0.0f))
        {
            Debug.Log(distance_apple_tree.ToString());
            Pulse(0.2f, 1, 150, SteamVR_Input_Sources.RightHand);
        }


    }


    void OnCollisionStay(Collision collision)
    {

        //if (collision.gameObject.tag == "apple_VIVE"){
        //    Debug.Log("collision detected")   ;
        //    isCurrentlyCollidingWApple = true ;
        //}

        //if (collision.gameObject.tag == "box_VIVE"){
        //    print("collision detected")     ;
        //    isCurrentlyCollidingWBox = true ;
        //}

        //if (collision.gameObject.tag == "tree_VIVE")
        //{
         //   isCurrentlyCollidingWTree = true;
        //}
        //Pulse(0.2f, 1, 300, SteamVR_Input_Sources.RightHand);

        //if (isCurrentlyCollidingWTree == true)
        //{
        //    Pulse(1, 30, 30, SteamVR_Input_Sources.RightHand);
        //}

        if (collision.gameObject.tag == "InnerCube_InTree")
            Pulse(1, 30, 30, SteamVR_Input_Sources.RightHand);

    }


    void OnCollisionExit(Collision collision){

        //isCurrentlyCollidingWApple = false ;
        isCurrentlyCollidingWTree = false  ;
        //isCurrentlyCollidingWBox = false   ;

    }


}