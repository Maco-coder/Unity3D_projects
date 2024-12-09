using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;

public class Knee_Physical_Virtual_Collocation : MonoBehaviour
{

    public GameObject manikin           ;

    public Transform tracker1           ;
    private bool hasInitialized = false ;
    
    private Vector3 initialTrackerPosition   ;
    private Quaternion initialTrackerRotation;


    void Start()
    {

    }

    void Update()
    {

        if (!hasInitialized && tracker1 != null)
        {
            initialTrackerPosition = tracker1.position;
            initialTrackerRotation = tracker1.rotation;
            hasInitialized = true                    ;
        }

        if (hasInitialized && tracker1 != null)
        {

            Debug.Log("Initial Tracker Position: " + initialTrackerPosition) ;
            manikin.transform.position = initialTrackerPosition ;
            manikin.transform.rotation = initialTrackerRotation ;

        }
    }
}