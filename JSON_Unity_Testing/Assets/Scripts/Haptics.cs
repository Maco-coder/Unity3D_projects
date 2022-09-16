using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class Haptics : MonoBehaviour
{

    public GameObject Cube2  ;
    public GameObject apple  ;
    public GameObject tree   ;
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

        distance_ = Vector3.Distance(tree.transform.position,apple.transform.position);
        
        //float triggerValueR = squeezeAction.GetAxis(SteamVR_Input_Sources.RightHand);

        if (distance_ > 0.0f)
        {
            print(triggerValueR);


            // SPRING FEEDBACK //

            if(myFeedbackList.feedback[1].type=="spring"){
                
                if(myFeedbackList.feedback[1].magnitude=="10"){
                    Pulse(1, distance_, 10, SteamVR_Input_Sources.RightHand);
                }
                if(myFeedbackList.feedback[1].magnitude=="40"){
                    Pulse(1, distance_, 40, SteamVR_Input_Sources.RightHand);
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