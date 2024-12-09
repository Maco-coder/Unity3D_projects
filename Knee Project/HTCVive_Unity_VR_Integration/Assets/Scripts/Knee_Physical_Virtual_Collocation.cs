using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;

public class Knee_Physical_Virtual_Collocation : MonoBehaviour
{

    public GameObject manikin             ;

    public Transform tracker              ;
    private bool hasInitialized = false   ;
    
    private Vector3 initialTrackerPosition   ;
    private Quaternion initialTrackerRotation;


    void Start()
    {

    }

    void Update()
    {

        if (!hasInitialized && tracker != null)
        {
            initialTrackerPosition = tracker.position;
            initialTrackerRotation = tracker.rotation;
            hasInitialized = true                    ;
        }

        if (hasInitialized && tracker != null)
        {

            Debug.Log("Initial Tracker Position: " + initialTrackerPosition) ;
            manikin.transform.position = initialTrackerPosition ;
            manikin.transform.rotation = initialTrackerRotation ;

        }
    }
}