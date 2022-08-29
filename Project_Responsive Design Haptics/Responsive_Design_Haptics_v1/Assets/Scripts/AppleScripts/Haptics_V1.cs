
using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;
using Valve.VR                  ;


public class Haptics_V1 : MonoBehaviour
{
    public SteamVR_Action_Single squeezeAction   ;
    public SteamVR_Action_Vibration hapticAction ;

    void Update()
    {

        float triggerValueL = squeezeAction.GetAxis(SteamVR_Input_Sources.LeftHand);

        if (triggerValueL > 0.0f)
        {
            print(triggerValueL);
            Pulse(StoreVariables.VRcontroller_GRAB_pulse_time, StoreVariables.VRcontroller_GRAB_pulse_frequency, StoreVariables.VRcontroller_GRAB_pulse_amplitude, SteamVR_Input_Sources.LeftHand);
            //Pulse(1, 150, 75, SteamVR_Input_Sources.LeftHand);
        }


        float triggerValueR = squeezeAction.GetAxis(SteamVR_Input_Sources.RightHand);

        if (triggerValueR > 0.0f)
        {
            print(triggerValueR);
            Pulse(StoreVariables.VRcontroller_GRAB_pulse_time, StoreVariables.VRcontroller_GRAB_pulse_frequency, StoreVariables.VRcontroller_GRAB_pulse_amplitude, SteamVR_Input_Sources.RightHand);
            //Pulse(1, 150, 75, SteamVR_Input_Sources.LeftHand);
        }

    }

    private void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        hapticAction.Execute(0, duration, frequency, amplitude, source);
        print("Pulse" + "" + source.ToString());
    }

}