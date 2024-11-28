using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;

public class Rotation_NewBehaviourScript : MonoBehaviour
{

    public GameObject viveTracker1 ;
    public GameObject knee         ;

    float offset_x_tracker1 = 92.0f ;
    float offset_y_tracker1 = 79.0f ;
    float offset_z_tracker1 = 79.0f ;

    float offset_x_knee = 1.07f  ;
    float offset_y_knee = 0.454f ;
    float offset_z_knee = 0.454f ;


    void Start()
    {

    }

    void Update()
    {

        Quaternion rotationViveTracker1 = viveTracker1.transform.rotation     ;
        Vector3 eulerRotationViveTracker1 = viveTracker1.transform.eulerAngles;

        eulerRotationViveTracker1.x = NormalizeAngle(eulerRotationViveTracker1.x);
        eulerRotationViveTracker1.y = NormalizeAngle(eulerRotationViveTracker1.y);
        eulerRotationViveTracker1.z = NormalizeAngle(eulerRotationViveTracker1.z);

        Vector3 eulerRotationKnee = knee.transform.eulerAngles;
        eulerRotationKnee.x = eulerRotationViveTracker1.x     ;
        eulerRotationKnee.y = eulerRotationViveTracker1.y     ;
        eulerRotationKnee.z = eulerRotationViveTracker1.z     ;

        //rotationKnee.x = -(rotationViveTracker1.x + (offset_x_tracker1 - offset_x_knee));
        //rotationKnee.z = (rotationViveTracker1.y + (offset_y_tracker1 - offset_y_knee)) ;

        knee.transform.eulerAngles = eulerRotationKnee;

        //float rotationX = knee.transform.eulerAngles.x;
        //float rotationY = knee.transform.eulerAngles.y;

        Debug.Log("Tracker X Rotation: " + eulerRotationKnee.x.ToString("F2") + " Tracker Y Rotation: " + eulerRotationKnee.y.ToString("F2"));

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