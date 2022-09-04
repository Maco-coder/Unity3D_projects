using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class Haptics : MonoBehaviour
{

    public GameObject Cube2  ;
    public TextAsset textJSON;

    [System.Serializable]
    public class Data
    {
        public string type     ;
        public string magnitude;
        public string geometry ;
    }

    [System.Serializable]
    public class List
    {
        public Data[] feedback ;

    }

    public List myFeedbackList = new List();

    public SteamVR_Action_Single squeezeAction  ;
    public SteamVR_Action_Vibration hapticAction;


    void Start()
    {
        myFeedbackList = JsonUtility.FromJson<List>(textJSON.text);
        print(myFeedbackList.feedback[0].type);

    }


    void Update()
    {

        float triggerValueL = squeezeAction.GetAxis(SteamVR_Input_Sources.LeftHand);

        if (triggerValueL > 0.0f)
        {
            print(triggerValueL);
            Pulse(2, 150, 75, SteamVR_Input_Sources.LeftHand);
        }


        float triggerValueR = squeezeAction.GetAxis(SteamVR_Input_Sources.RightHand);

        if (triggerValueR > 0.0f)
        {
            print(triggerValueR);
            Pulse(2, 150, 75, SteamVR_Input_Sources.LeftHand);
        }

    }

    private void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        hapticAction.Execute(0, duration, frequency, amplitude, source);
        print("Pulse" + "" + source.ToString());
    }

}