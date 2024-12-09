using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;

public class Knee_Physical_Virtual_Collocation : MonoBehaviour
{

    public GameObject manikin ;
    public GameObject hip1    ;

    public Transform tracker1           ;
    private bool hasInitialized = false ;
    
    private Vector3 initialTrackerPosition     ;
    private Quaternion initialTracker1Rotation ;


    void Start()
    {

    }

    void Update()
    {

        //Quaternion VIVErotation1 = tracker1.rotation ;

        if (hasInitialized == false && tracker1 != null)
        {
            initialTrackerPosition = tracker1.position  ;
            initialTracker1Rotation = tracker1.rotation ;
            manikin.transform.position = initialTrackerPosition;
            hasInitialized = true ;
        }

        if (hasInitialized == true && tracker1 != null)
        {

            Debug.Log("Initial Tracker Position: " + hasInitialized) ;
            //manikin.transform.position = initialTrackerPosition ;

            //Quaternion currentTracker1Rotation = tracker1.rotation ;
            //Quaternion relativeInitialRotation1 = Quaternion.Inverse(initialTracker1Rotation) * currentTracker1Rotation ;
            //Vector3 relativeEurlerAngles_Hip1 = relativeInitialRotation1.eulerAngles ;
            //Vector3 eulerRotationHip1 = hip1.transform.localEulerAngles              ;
            //eulerRotationHip1.x = NormalizeAngles(relativeEurlerAngles_Hip1.x)       ;
            //eulerRotationHip1.y = NormalizeAngles(relativeEurlerAngles_Hip1.y) ;
            //eulerRotationHip1.z = NormalizeAngles(relativeEurlerAngles_Hip1.z) ;

            //hip1.transform.localEulerAngles = eulerRotationHip1 ;

        }
    }

    float NormalizeAngles(float angles)
    {
        if (angles > 180)
            angles -= -360;
        else if (angles < -180)
            angles += 360;
        return angles;
    }
}