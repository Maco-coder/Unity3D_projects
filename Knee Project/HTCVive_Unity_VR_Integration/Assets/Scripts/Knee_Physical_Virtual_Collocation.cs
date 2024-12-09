using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;

public class Knee_Physical_Virtual_Collocation : MonoBehaviour
{

    public Transform tracker            ;
    private bool hasInitialized = false ;
    private Vector3 initialTrackerPosition;


    void Start()
    {
        
    }

    void Update()
    {

        if(!hasInitialized && tracker != null)
        {
            initialTrackerPosition = tracker.position ;
            hasInitialized = true                     ;
        }

        if (hasInitialized && tracker != null)
        {

            //Debug.Log("Initial Tracker Position: " + initialTrackerPosition);

        }
    }