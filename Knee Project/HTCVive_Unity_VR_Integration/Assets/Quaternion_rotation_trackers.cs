using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;

public class Quaternion_rotation_trackers : MonoBehaviour
{

    public GameObject knee ;

    public Transform tracker1   ;
    public Transform tracker2   ;
    public Transform virtualKnee;


    void Start()
    {
        
    }

    void Update()
    {
        // Get the rotation of both trackers (in world space)
        Quaternion VIVErotation1 = tracker1.rotation ;
        Quaternion VIVErotation2 = tracker2.rotation ;

        // Calculate the relative rotation between the two trackers
        Quaternion relativeRotation = Quaternion.Inverse(VIVErotation1)*VIVErotation2 ;
        Vector3 relativeEulerAngles = relativeRotation.eulerAngles                    ;

        Vector3 eulerRotationKnee = knee.transform.localEulerAngles ;
        eulerRotationKnee.x = NormalizeAngle(relativeEulerAngles.x) ;
        //eulerRotationKnee.y = NormalizeAngle(relativeEulerAngles.y) ;
        eulerRotationKnee.z = NormalizeAngle(relativeEulerAngles.z) - 32.0f ;

        // Apply the relative rotation to the virtual knee
        
        virtualKnee.rotation = relativeRotation            ;
        knee.transform.localEulerAngles = eulerRotationKnee;

        Debug.Log("X Rotation: " + eulerRotationKnee.x.ToString("F2") + " Tracker Y Rotation: " + eulerRotationKnee.y.ToString("F2"));
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
