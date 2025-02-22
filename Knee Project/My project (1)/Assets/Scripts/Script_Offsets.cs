using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;

public class Script_Offsets : MonoBehaviour
{

    public GameObject Hip_reference ;
    public GameObject Manikin_body  ;
    public GameObject Manikin_hip   ;
    public GameObject Manikin_knee  ;

    public Transform Upper_leg_cube ;
    public Transform Lower_leg_cube ;

    public Vector3 Manikin_position_offset ;
    //public Vector3 Manikin_rotation_hip_offset  ;
    //public Vector3 Manikin_rotation_knee_offset ;

    //private Vector3 hip_desired_angles = new Vector3(0f, 0f, -180f);
    //private Vector3 knee_desired_angles = new Vector3(0f, 0f, 0f)  ;

    private float hip_desired_angle_x = 0f   ;
    private float hip_desired_angle_y = 0f   ;
    private float hip_desired_angle_z = -180f;

    private bool hasReadOffsets = false;

    private Vector3 Upper_leg_offsets ;
    private Vector3 Lower_leg_offsets ;


    void Start()
    {

    }

    void Update()
    {

        Quaternion Upper_leg_rotation_cube = Upper_leg_cube.rotation ;
        Quaternion Lower_leg_rotation_cube = Lower_leg_cube.rotation ;
        Vector3 Hip_reference_position = Hip_reference.transform.position           ;
        Vector3 Manikin_position = Hip_reference_position + Manikin_position_offset ;


        if (hasReadOffsets == false && Upper_leg_cube != null && Lower_leg_cube != null)
        {

            Vector3 Upper_leg_EulerAngles = Upper_leg_rotation_cube.eulerAngles;
            Upper_leg_EulerAngles = new Vector3(NormalizeAngle(Upper_leg_EulerAngles.x), NormalizeAngle(Upper_leg_EulerAngles.y), NormalizeAngle(Upper_leg_EulerAngles.z));
            
            Vector3 eulerRotationHip = Manikin_hip.transform.localEulerAngles   ;
            eulerRotationHip.x = hip_desired_angle_x - Upper_leg_EulerAngles.x ;
            eulerRotationHip.y = hip_desired_angle_y - Upper_leg_EulerAngles.y ;
            eulerRotationHip.z = hip_desired_angle_z - Upper_leg_EulerAngles.z ;


            //Vector3 Lower_leg_EulerAngles = Lower_leg_rotation_cube.eulerAngles;
            //Lower_leg_EulerAngles = new Vector3(NormalizeAngle(Lower_leg_EulerAngles.x), NormalizeAngle(Lower_leg_EulerAngles.y), NormalizeAngle(Lower_leg_EulerAngles.z));

            Debug.Log("Data: " + eulerRotationHip);

            hasReadOffsets = true ;

        }

        


        if (hasReadOffsets == true && Upper_leg_cube != null && Lower_leg_cube != null)
        {
            Manikin_body.transform.position = Manikin_position;

            //Debug.Log("Data: " + eulerRotationHip);

            //Manikin_hip.transform.localEulerAngles = eulerRotationHip + Upper_leg_EulerAngles;

            //Manikin_hip.transform.localEulerAngles = Upper_leg_EulerAngles + Upper_leg_offsets;
            //Manikin_knee.transform.localEulerAngles = Lower_leg_rotation_cube.eulerAngles + Lower_leg_offsets;

        }
    }

    private float NormalizeAngle(float angle)
    {
        if (angle > 180f)
        {
            angle -= 360f;
        }
        return angle;
    }

}