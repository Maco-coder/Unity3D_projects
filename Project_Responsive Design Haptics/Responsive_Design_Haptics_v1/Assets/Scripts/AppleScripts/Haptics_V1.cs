
using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;
using Valve.VR                  ;


public class Haptics_V1 : MonoBehaviour
{
    public SteamVR_Action_Single squeezeAction   ;
    public SteamVR_Action_Vibration hapticAction ;

    bool LisCurrentlyColliding ;
    bool RisCurrentlyColliding ;


    void Update()
    {

        float triggerValueL = squeezeAction.GetAxis(SteamVR_Input_Sources.LeftHand);

        if ( (triggerValueL > 0.0f) && LisCurrentlyColliding)  // IF GRASPING APPLE WITH HANDS WHILE ON TREE //
        //if (triggerValueL > 0.0f)
        {
            print(triggerValueL);
            Pulse(1, 150, 75, SteamVR_Input_Sources.LeftHand);
        }


        float triggerValueR = squeezeAction.GetAxis(SteamVR_Input_Sources.RightHand);

        if ( (triggerValueR > 0.0f) && RisCurrentlyColliding )  // IF GRASPING APPLE WITH HANDS WHILE ON TREE //
        {
            print(triggerValueR);
            Pulse(1, 150, 75, SteamVR_Input_Sources.RightHand);
        }

    }


    private void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        hapticAction.Execute(0, duration, frequency, amplitude, source);
        print("Pulse" + "" + source.ToString());
    }


    void OnCollisionEnter(Collision collision){
        
        if (collision.gameObject.name == "LHand"){
            Debug.Log("Left hand touching apple") ;
            LisCurrentlyColliding = true          ;
        }

        if (collision.gameObject.name == "RHand"){
            Debug.Log("Right hand touching apple") ;
            RisCurrentlyColliding = true           ;
        }
        
    }

    void OnCollisionExit(Collision collision){

        LisCurrentlyColliding = false ;
        RisCurrentlyColliding = false ;
        
    }

}