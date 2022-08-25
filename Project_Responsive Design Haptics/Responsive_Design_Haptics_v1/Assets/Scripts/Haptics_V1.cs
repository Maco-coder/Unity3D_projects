
using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;
using Valve.VR                  ;


public class Haptics_V1 : MonoBehaviour
{
    public SteamVR_Action_Single squeezeAction   ;


    void Update()
    {

        float triggerValueL = squeezeAction.GetAxis(SteamVR_Input_Sources.LeftHand);

        if (triggerValueL > 0.0f)
        {
            print(triggerValueL);
            Pulse(1, 150, 75, SteamVR_Input_Sources.LeftHand);
        }


        float triggerValueR = squeezeAction.GetAxis(SteamVR_Input_Sources.RightHand);

        if (triggerValueR > 0.0f)
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

}
