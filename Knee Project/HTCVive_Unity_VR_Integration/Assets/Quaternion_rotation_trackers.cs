
using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;

public class Quaternion_rotation_trackers : MonoBehaviour
{

    public GameObject knee    ;
    public GameObject hip     ;
    public GameObject redCube ;

    public Transform tracker1 ;
    public Transform tracker2 ;

    public Transform trackerTransform         ;
    private Quaternion initialTrackerRotation ;
    private bool hasInitialized = false       ;


    void Start()
    {
        //initialTrackerRotation = trackerTransform.rotation;
    }


    void Update()
    {
        // Get the rotation of both trackers (in world space)
        Quaternion VIVErotation1 = tracker1.rotation ;
        Quaternion VIVErotation2 = tracker2.rotation ;


        // CORRECTING HIP JOINT ROTATION //

        if (!hasInitialized && trackerTransform != null)
        {
            // Capture the initial rotation of the tracker
            initialTrackerRotation = trackerTransform.rotation;
            Debug.Log("Initial Tracker Rotation: " + initialTrackerRotation.eulerAngles);
            hasInitialized = true;
        }
        
        if (hasInitialized && trackerTransform != null)
        {
            Quaternion currentTrackerRotation = trackerTransform.rotation;
            Quaternion relativeInitialRotation = currentTrackerRotation * Quaternion.Inverse(initialTrackerRotation);
            redCube.transform.rotation = relativeInitialRotation ;
            //Debug.Log("Initial Tracker Rotation: " + initialTrackerRotation.eulerAngles);
            //Debug.Log("Current Tracker Rotation: " + currentTrackerRotation.eulerAngles);
            //Debug.Log("Relative Rotation: " + relativeInitialRotation.eulerAngles)      ;


            // KNEE JOINT //

            // Calculate the relative rotation between the two trackers
            Quaternion relativeRotation = Quaternion.Inverse(VIVErotation1) * VIVErotation2;
            Vector3 relativeEulerAngles_knee = relativeRotation.eulerAngles;

            Vector3 eulerRotationKnee = knee.transform.localEulerAngles;
            eulerRotationKnee.x = NormalizeAngle(relativeEulerAngles_knee.x) + 0.508f;
            //eulerRotationKnee.y = NormalizeAngle(relativeEulerAngles.y) ;
            eulerRotationKnee.z = - NormalizeAngle(relativeEulerAngles_knee.z) + 1.90f;

            // Apply the relative rotation to the virtual knee
            knee.transform.localEulerAngles = eulerRotationKnee;


            // HIP JOINT //

            //Vector3 relativeEulerAngles_hip = VIVErotation2.eulerAngles;
            Vector3 relativeEulerAngles_hip = relativeInitialRotation.eulerAngles;

            Vector3 eulerRotationHip = hip.transform.localEulerAngles        ;
            eulerRotationHip.x = (NormalizeAngle(relativeEulerAngles_hip.z)) ;
            eulerRotationHip.y = (NormalizeAngle(relativeEulerAngles_hip.x)) ;
            eulerRotationHip.z = 180 + (NormalizeAngle(relativeEulerAngles_hip.y)) ;

            hip.transform.localEulerAngles = eulerRotationHip;

        }

    }


    float NormalizeAngle(float angle)
    {
        if (angle > 180)
            angle -= 360;
        else if (angle < -180)
            angle += 360;
        return angle;
    }

}