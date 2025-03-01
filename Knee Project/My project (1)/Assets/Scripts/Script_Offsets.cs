using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;

public class Script_Offsets : MonoBehaviour
{

    public GameObject Hip_reference ;
    public GameObject Manikin_body  ;
    public GameObject Manikin_hip   ;
    public GameObject Manikin_knee  ;
    public GameObject Manikin_child ;

    public Transform Upper_leg_cube ;
    public Transform Lower_leg_cube ;
    public Transform Hip_reference_body;

    private Vector3 Manikin_position_offset = new Vector3(0.093f, 0.017f, -1.135f) ;  // relative to the hip-reference cube //


    private float manikin_desired_angle_x = 0f ;
    private float manikin_desired_angle_y = 0f ;
    private float manikin_desired_angle_z = 0f ;

    private float hip_desired_angle_x = 0f   ;
    private float hip_desired_angle_y = 0f   ;
    private float hip_desired_angle_z = -180f;

    private float knee_desired_angle_x = 0f ;
    private float knee_desired_angle_y = 0f ;
    private float knee_desired_angle_z = 0f ;

    private bool hasReadOffsets = false;

    private Vector3 Upper_leg_offsets  ;
    private Vector3 Lower_leg_offsets  ;
    private Vector3 Hip_reference_offsets;


    void Start()
    {

    }

    void Update()
    {

        Quaternion Upper_leg_rotation_cube = Upper_leg_cube.rotation ;
        Quaternion Lower_leg_rotation_cube = Lower_leg_cube.rotation ;
        Quaternion Hip_rotation_cube = Hip_reference_body.rotation   ;


        if (hasReadOffsets == false && Upper_leg_cube.transform.position != Vector3.zero && Lower_leg_cube.transform.position != Vector3.zero && Hip_reference_body.transform.position != Vector3.zero)
        {

            Vector3 Upper_leg_EulerAngles = Upper_leg_rotation_cube.eulerAngles;
            Upper_leg_EulerAngles = new Vector3(NormalizeAngle(Upper_leg_EulerAngles.x), NormalizeAngle(Upper_leg_EulerAngles.y), NormalizeAngle(Upper_leg_EulerAngles.z));

            Debug.Log("Data: " + Upper_leg_EulerAngles) ;

            Vector3 eulerRotationHip;
            eulerRotationHip.x = hip_desired_angle_x - Upper_leg_EulerAngles.x ;
            eulerRotationHip.y = hip_desired_angle_y - (-Upper_leg_EulerAngles.z) ;
            eulerRotationHip.z = hip_desired_angle_z - Upper_leg_EulerAngles.y ;
            Upper_leg_offsets = eulerRotationHip;


            Vector3 Lower_leg_EulerAngles = Lower_leg_rotation_cube.eulerAngles;
            Lower_leg_EulerAngles = new Vector3(NormalizeAngle(Lower_leg_EulerAngles.x), NormalizeAngle(Lower_leg_EulerAngles.y), NormalizeAngle(Lower_leg_EulerAngles.z));
            
            Vector3 eulerRotationKnee;
            eulerRotationKnee.x = knee_desired_angle_x - Lower_leg_EulerAngles.x;
            eulerRotationKnee.y = knee_desired_angle_y - (-Lower_leg_EulerAngles.z);
            eulerRotationKnee.z = knee_desired_angle_z - Lower_leg_EulerAngles.y;
            Lower_leg_offsets = eulerRotationKnee;


            Vector3 Hip_reference_EulerAngles = Hip_rotation_cube.eulerAngles ;
            Hip_reference_EulerAngles = new Vector3(NormalizeAngle(Hip_reference_EulerAngles.x), NormalizeAngle(Hip_reference_EulerAngles.y), NormalizeAngle(Hip_reference_EulerAngles.z));

            Vector3 eulerRotationBody;
            eulerRotationBody.x = manikin_desired_angle_x - Hip_reference_EulerAngles.x ;
            eulerRotationBody.y = manikin_desired_angle_y - Hip_reference_EulerAngles.y ;
            eulerRotationBody.z = manikin_desired_angle_z - Hip_reference_EulerAngles.z ;
            Hip_reference_offsets = eulerRotationBody;

            //Debug.Log("Data: " + eulerRotationHip) ;
            //Debug.Log("Data: " + eulerRotationKnee);

            //Debug.Log("Data: " + Hip_reference_EulerAngles);
            //Debug.Log("Data: " + eulerRotationBody);

            hasReadOffsets = true ;

        }

        
        if (hasReadOffsets == true)
        {
            Manikin_body.transform.position = Hip_reference.transform.position + Manikin_position_offset;  // Positions manikin where the reference cube (hip-reference) is //

            Vector3 R_bodyEulerAngles = Hip_reference_body.eulerAngles ;
            Vector3 R_upperLegEulerAngles = Upper_leg_cube.eulerAngles ;
            Vector3 R_lowerLegEulerAngles = Lower_leg_cube.eulerAngles ;

            Vector3 upperLegEulerAngles = new Vector3(NormalizeAngle(R_upperLegEulerAngles.x), NormalizeAngle(R_upperLegEulerAngles.y), NormalizeAngle(R_upperLegEulerAngles.z));
            Vector3 lowerLegEulerAngles = new Vector3(NormalizeAngle(R_upperLegEulerAngles.x), NormalizeAngle(R_upperLegEulerAngles.y), NormalizeAngle(R_upperLegEulerAngles.z));

            // Manually compute the new Euler angles:

            //float body_newX = (bodyEulerAngles.x + Hip_reference_offsets.x) ;
            //float body_newY = (bodyEulerAngles.y + Hip_reference_offsets.y) ;
            //float body_newZ = (bodyEulerAngles.z + Hip_reference_offsets.z) ;

            float body_newX = Hip_reference_body.eulerAngles.x;
            float body_newY = Hip_reference_body.eulerAngles.y;
            float body_newZ = Hip_reference_body.eulerAngles.z;
            Manikin_child.transform.localEulerAngles = new Vector3(body_newX, body_newZ, body_newY); // Orients manikin to the reference cube (not essential given that the table is flat) //

            float hip_newX = -(upperLegEulerAngles.x + Upper_leg_offsets.x);
            float hip_newY = -(upperLegEulerAngles.z + Upper_leg_offsets.y);
            float hip_newZ = (upperLegEulerAngles.y + Upper_leg_offsets.z) ;
            Manikin_hip.transform.localEulerAngles = new Vector3(hip_newX, hip_newY, hip_newZ);

            //Debug.Log("Data: " + hip_newY);
            //Debug.Log("DataY: " + hip_newX);
            //Debug.Log("DataZ: " + hip_newX);

            float knee_newX = (lowerLegEulerAngles.x + Lower_leg_offsets.x);
            float knee_newY = (lowerLegEulerAngles.z + Lower_leg_offsets.y);
            float knee_newZ = (lowerLegEulerAngles.y + Lower_leg_offsets.z);
            Manikin_knee.transform.localEulerAngles = new Vector3(knee_newX, knee_newY, knee_newZ);

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