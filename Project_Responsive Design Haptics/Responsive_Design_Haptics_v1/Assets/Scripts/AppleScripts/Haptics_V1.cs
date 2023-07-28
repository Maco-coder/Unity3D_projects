
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


    void Update()
    {

        float triggerValueL = squeezeAction.GetAxis(SteamVR_Input_Sources.LeftHand)  ;
        float triggerValueR = squeezeAction.GetAxis(SteamVR_Input_Sources.RightHand) ;

        if ( isCurrentlyCollidingWApple && isCurrentlyCollidingWTree ){

            Pulse(1, 100, 40, SteamVR_Input_Sources.LeftHand);
            
        }

        if ( isCurrentlyCollidingWApple ){

            Pulse(1, 50, 30, SteamVR_Input_Sources.LeftHand);
            
        }


        //if ( (triggerValueL > 0.0f) && LisCurrentlyColliding)  // IF GRASPING APPLE WITH HANDS WHILE ON TREE //
        //if (triggerValueL > 0.0f)
        //{
        //    print(triggerValueL);
        //    Pulse(1, 150, 75, SteamVR_Input_Sources.LeftHand);
        //}


        //if ( (triggerValueR > 0.0f) && RisCurrentlyColliding )  // IF GRASPING APPLE WITH HANDS WHILE ON TREE //
        //{
        //    print(triggerValueR);
        //    Pulse(1, 150, 75, SteamVR_Input_Sources.RightHand);
        //}

    }


    private void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        hapticAction.Execute(0, duration, frequency, amplitude, source);
        print("Pulse" + "" + source.ToString());
    }


    void OnCollisionEnter(Collision collision){
        
        if (collision.gameObject.name == "apple_VIVE"){
            isCurrentlyCollidingWApple = true ;
        }

        if (collision.gameObject.name == "tree_VIVE"){
            isCurrentlyCollidingWTree = true ;
        }
        
    }

    void OnCollisionExit(Collision collision){

        isCurrentlyCollidingWApple = false ;
        isCurrentlyCollidingWTree = false  ;
        
    }

}