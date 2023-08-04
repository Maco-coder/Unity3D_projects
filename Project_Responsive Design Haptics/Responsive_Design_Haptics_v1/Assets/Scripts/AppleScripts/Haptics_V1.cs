
using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;
using Valve.VR                  ;


public class Haptics_V1 : MonoBehaviour
{
    public SteamVR_Action_Single squeezeAction   ;
    public SteamVR_Action_Vibration hapticAction ;

    bool isCurrentlyCollidingWTree  ;
    bool isCurrentlyCollidingWApple ;
    bool isCurrentlyCollidingWBox   ;


    void Update()
    {

        float triggerValueL = squeezeAction.GetAxis(SteamVR_Input_Sources.LeftHand)  ;
        float triggerValueR = squeezeAction.GetAxis(SteamVR_Input_Sources.RightHand) ;

        //if ( isCurrentlyCollidingWApple == true && isCurrentlyCollidingWTree == true ){

        //    Pulse(1, 100, 40, SteamVR_Input_Sources.RightHand);
            
        //}

        //if ( isCurrentlyCollidingWApple == true ){

        //    Pulse(1, 50, 30, SteamVR_Input_Sources.RightHand);
            
        //}

        //if (isCurrentlyCollidingWBox == true)
        //{

        //    Pulse(1, 150, 30, SteamVR_Input_Sources.RightHand);

        //}


        //if ( (triggerValueL > 0.0f) && LisCurrentlyColliding)  // IF GRASPING APPLE WITH HANDS WHILE ON TREE //
        if ( (triggerValueL > 0.0f) && (isCurrentlyCollidingWBox == true))
        {
            print(triggerValueL);
            Pulse(1, 50, 75, SteamVR_Input_Sources.LeftHand);
        }


        if ( (triggerValueR > 0.0f) && (isCurrentlyCollidingWBox == true) )  // IF GRASPING APPLE WITH HANDS WHILE ON TREE //
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