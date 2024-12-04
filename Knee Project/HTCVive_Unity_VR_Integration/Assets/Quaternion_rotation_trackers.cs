using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;

public class Quaternion_rotation_trackers : MonoBehaviour
{

    public GameObject knee ;
    public GameObject hip  ;
    public GameObject redCube;

    public Transform tracker1 ;
    public Transform tracker2 ;

    public Transform trackerTransform   ;
    private Quaternion initialTrackerRotation ;
    private bool hasInitialized = false ;
    
    //public Transform virtualKnee;
    //public Transform virtualHip ;


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

        //Quaternion additionalRotation = Quaternion.Euler(50,10,88.05f);
        //redCube.transform.rotation = trackerRotation * additionalRotation ;

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
            redCube.transform.rotation = relativeInitialRotation;
            Debug.Log("Initial Tracker Rotation: " + initialTrackerRotation.eulerAngles);
            Debug.Log("Current Tracker Rotation: " + currentTrackerRotation.eulerAngles);
            Debug.Log("Relative Rotation: " + relativeInitialRotation.eulerAngles);
        }


        // KNEE JOINT //

        // Calculate the relative rotation between the two trackers
        Quaternion relativeRotation = Quaternion.Inverse(VIVErotation1)*VIVErotation2 ;
        Vector3 relativeEulerAngles_knee = relativeRotation.eulerAngles               ;

        Vector3 eulerRotationKnee = knee.transform.localEulerAngles ;
        eulerRotationKnee.x = NormalizeAngle(relativeEulerAngles_knee.x) - 0.80f ;
        //eulerRotationKnee.y = NormalizeAngle(relativeEulerAngles.y) ;
        eulerRotationKnee.z = - (NormalizeAngle(relativeEulerAngles_knee.z) + 38.6f) ;

        // Apply the relative rotation to the virtual knee
        //virtualKnee.rotation = relativeRotation;
        knee.transform.localEulerAngles = eulerRotationKnee;


        // HIP JOINT //

        Vector3 relativeEulerAngles_hip = VIVErotation2.eulerAngles ;

        Vector3 eulerRotationHip = hip.transform.localEulerAngles   ;
        eulerRotationHip.x = -(NormalizeAngle(relativeEulerAngles_hip.x) + 88.3f) ;
        //eulerRotationHip.y = -(NormalizeAngle(relativeEulerAngles_hip.y));
        //eulerRotationHip.z = -180.0f -(NormalizeAngle(relativeEulerAngles_hip.y)) ;
        //eulerRotationHip.z = NormalizeAngle(relativeEulerAngles_hip.z + 359.8f );

        hip.transform.localEulerAngles = eulerRotationHip ;





        //float modifiedX = VIVErotation2.x;
        //float modifiedY = 0f;  // Zero out the Y component
        //float modifiedZ = 0f;

        //Quaternion modifiedRotation = new Quaternion(modifiedX, modifiedY, modifiedZ, VIVErotation2.w);
        
        //virtualHip.rotation = VIVErotation2;

        //Debug.Log("Knee X Rotation: " + eulerRotationKnee.x.ToString("F2") + " Knee Y Rotation: " + eulerRotationKnee.y.ToString("F2"));
        //Debug.Log("Hip X Rotation: " + eulerRotationHip.x.ToString("F2") + " Hip Y Rotation: " + eulerRotationHip.y.ToString("F2"));
        //Debug.Log("Knee X Rotation: " + virtualHip.rotation.x.ToString("F2") + " Knee Y Rotation: " + virtualHip.rotation.y.ToString("F2") + " Knee Z Rotation: " + virtualHip.rotation.z.ToString("F2"));
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