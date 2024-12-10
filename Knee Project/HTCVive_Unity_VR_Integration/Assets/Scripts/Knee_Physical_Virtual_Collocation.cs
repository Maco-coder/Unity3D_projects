using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;

public class Knee_Physical_Virtual_Collocation : MonoBehaviour
{

    public GameObject manikin ;
    public GameObject hip1    ;
    public GameObject knee1   ;

    public Transform tracker1 ;   // Upper Leg Tracker
    public Transform tracker2 ;   // Lower Leg Tracker

    private bool hasInitialized = false ;
    
    private Vector3 initialTracker1Position    ;
    private Quaternion initialTracker1Rotation ;

    private float initialOffset_knee_x ;
    private float initialOffset_knee_y ;
    private float initialOffset_knee_z ;


    void Start()
    {

    }

    void Update()
    {

        Quaternion VIVErotation1 = tracker1.rotation ;
        Quaternion VIVErotation2 = tracker2.rotation ;

        if (hasInitialized == false && tracker1 != null)
        {
            initialTracker1Position = tracker1.position ;
            initialTracker1Rotation = tracker1.rotation ;
            manikin.transform.position = initialTracker1Position ;
            manikin.transform.rotation = initialTracker1Rotation ;
            hasInitialized = true ;
        }

        if (hasInitialized == true && tracker1 != null)
        {

            // HIP JOINT KINEMATICS //

            Quaternion currentTracker1Rotation = tracker1.rotation ;
            Quaternion relativeInitialRotation1 = Quaternion.Inverse(initialTracker1Rotation) * currentTracker1Rotation ;
            Vector3 relativeEurlerAngles_Hip1 = relativeInitialRotation1.eulerAngles ;
            Vector3 eulerRotationHip1 = hip1.transform.localEulerAngles              ;
            eulerRotationHip1.x = NormalizeAngles(relativeEurlerAngles_Hip1.x)       ;
            eulerRotationHip1.y = - NormalizeAngles(relativeEurlerAngles_Hip1.y)     ;
            eulerRotationHip1.z = 180 + NormalizeAngles(relativeEurlerAngles_Hip1.z) ;

            hip1.transform.localEulerAngles = eulerRotationHip1 ;


            // KNEE JOINT KINEMATICS //

            Quaternion relativeRotation = Quaternion.Inverse(VIVErotation2) * VIVErotation1 ;
            Vector3 relativeEulerAngles_knee = relativeRotation.eulerAngles ;

            Vector3 eulerRotationKnee = knee1.transform.localEulerAngles ;
            eulerRotationKnee.x = NormalizeAngles(relativeEulerAngles_knee.x) - 0.540f  ;
            //eulerRotationKnee.y = NormalizeAngles(relativeEulerAngles_knee.y) ;
            eulerRotationKnee.z = - NormalizeAngles(relativeEulerAngles_knee.z) + 0.60f ;
            knee1.transform.localEulerAngles = eulerRotationKnee ;


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