using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;

public class Rotation_NewBehaviourScript : MonoBehaviour
{

    public GameObject viveTracker1 ;
    public GameObject viveTracker2 ;
    public GameObject knee_low     ;
    public GameObject knee_high    ;

    //float offset_x_tracker1 = 92.0f ;
    //float offset_y_tracker1 = 79.0f ;
    //float offset_z_tracker1 = 79.0f ;

    //float offset_x_knee = 1.07f  ;
    //float offset_y_knee = 0.454f ;
    //float offset_z_knee = 0.454f ;


    void Start()
    {

    }

    void Update()
    {

        // VR TRACKER ON LOWER LEG //

        Quaternion rotationViveTracker1 = viveTracker1.transform.rotation      ;
        Vector3 eulerRotationViveTracker1 = viveTracker1.transform.eulerAngles ;

        eulerRotationViveTracker1.x = NormalizeAngle(eulerRotationViveTracker1.x) ;
        eulerRotationViveTracker1.y = NormalizeAngle(eulerRotationViveTracker1.y) ;
        eulerRotationViveTracker1.z = NormalizeAngle(eulerRotationViveTracker1.z) ;

        Vector3 eulerRotationKnee_low = knee_low.transform.eulerAngles;
        eulerRotationKnee_low.x = eulerRotationViveTracker1.x ;
        eulerRotationKnee_low.y = eulerRotationViveTracker1.y ;
        eulerRotationKnee_low.z = eulerRotationViveTracker1.z ;

        knee_low.transform.eulerAngles = eulerRotationKnee_low;



        // VR TRACKER ON UPPER LEG //

        Quaternion rotationViveTracker2 = viveTracker2.transform.rotation     ;
        Vector3 eulerRotationViveTracker2 = viveTracker2.transform.eulerAngles;

        eulerRotationViveTracker2.x = NormalizeAngle(eulerRotationViveTracker2.x);
        eulerRotationViveTracker2.y = NormalizeAngle(eulerRotationViveTracker2.y);
        eulerRotationViveTracker2.z = NormalizeAngle(eulerRotationViveTracker2.z);

        Vector3 eulerRotationKnee_high = knee_high.transform.eulerAngles;
        eulerRotationKnee_high.x = eulerRotationViveTracker2.x ;
        eulerRotationKnee_high.y = eulerRotationViveTracker2.y ;
        eulerRotationKnee_high.z = eulerRotationViveTracker2.z ;

        knee_high.transform.eulerAngles = eulerRotationKnee_high;

        //float rotationX = knee.transform.eulerAngles.x;
        //float rotationY = knee.transform.eulerAngles.y;

        //Debug.Log("Tracker X Rotation: " + eulerRotationKnee.x.ToString("F2") + " Tracker Y Rotation: " + eulerRotationKnee.y.ToString("F2"));

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