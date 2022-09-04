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
        print(myFeedbackList.feedback[1].type)     ;
        print(myFeedbackList.feedback[1].magnitude);
        print(myFeedbackList.feedback[1].geometry) ;
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


            // SPRING FEEDBACK //

            if(myFeedbackList.feedback[1].type=="spring"){
                
                if(myFeedbackList.feedback[1].magnitude=="weak"){
                    Pulse(2, 50, 75, SteamVR_Input_Sources.LeftHand);
                }
                if(myFeedbackList.feedback[1].magnitude=="strong"){
                    Pulse(2, 200, 75, SteamVR_Input_Sources.LeftHand);
                }

            }


            // WEIGHT FEEDBACK //

            if(myFeedbackList.feedback[1].type=="weight"){
                
                if(myFeedbackList.feedback[1].magnitude=="20"){
                    Pulse(1, 100, 75, SteamVR_Input_Sources.LeftHand);
                }
                if(myFeedbackList.feedback[1].magnitude=="60"){
                    Pulse(1, 200, 30, SteamVR_Input_Sources.LeftHand);
                }

            }

        }

    }

    private void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        hapticAction.Execute(0, duration, frequency, amplitude, source);
        print("Pulse" + "" + source.ToString());
    }

}