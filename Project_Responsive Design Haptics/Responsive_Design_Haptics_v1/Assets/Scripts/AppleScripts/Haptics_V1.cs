
using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;
using Valve.VR                  ;


public class Haptics_V1 : MonoBehaviour
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



        if ( (triggerValueL > 0.0f) )
        {
            print(triggerValueL);
            Pulse(1, 50, 75, SteamVR_Input_Sources.LeftHand);
        }

        if ( (distance_apple_tree > 1) && (distance_apple_tree < 4))
        //if ( (triggerValueR > 0.0f) && (distance_apple_tree > 1) )
        {
            print(triggerValueR);
            Pulse(1, 50, 75, SteamVR_Input_Sources.RightHand);
        }

    }


    private void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        hapticAction.Execute(0, duration, frequency, amplitude, source);
        print("Pulse" + "" + source.ToString());
    }


    void OnCollisionEnter(Collision collision){

        if (collision.gameObject.tag == "apple_VIVE"){
            Debug.Log("collision detected")   ;
            isCurrentlyCollidingWApple = true ;
        }

        if (collision.gameObject.tag == "box_VIVE"){
            print("collision detected")     ;
            isCurrentlyCollidingWBox = true ;
        }

        if (collision.gameObject.tag == "tree_VIVE"){
            isCurrentlyCollidingWTree = true ;
        }

    }

    void OnCollisionExit(Collision collision){

        isCurrentlyCollidingWApple = false ;
        isCurrentlyCollidingWTree = false  ;
        isCurrentlyCollidingWBox = false   ;

    }

}