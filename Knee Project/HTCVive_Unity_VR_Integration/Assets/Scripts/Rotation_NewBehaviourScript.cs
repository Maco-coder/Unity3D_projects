using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;

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

        Vector3 rotationViveTracker1 = viveTracker1.transform.localEulerAngles;
        Vector3 rotationKnee = knee.transform.localEulerAngles;
        
        rotationKnee.x = -(rotationViveTracker1.x + (offset_x_tracker1 - offset_x_knee));
        //rotationKnee.z = (rotationViveTracker1.y + (offset_y_tracker1 - offset_y_knee)) ;

        knee.transform.localEulerAngles = rotationKnee;

        //float rotationX = knee.transform.localEulerAngles.x;

        //Debug.Log("Knee X Rotation: " + rotationX.ToString("F2"));

    }
}