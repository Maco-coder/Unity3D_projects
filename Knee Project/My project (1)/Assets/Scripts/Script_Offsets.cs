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

    private Vector3 hip_desired_angles = new Vector3(0f, 0f, -180f);
    private Vector3 knee_desired_angles = new Vector3(0f, 0f, 0f)  ;

    private bool hasReadOffsets = false;

    private Vector3 Upper_leg_offsets ;
    private Vector3 Lower_leg_offsets = Vector3.zero;


    void Start()
    {

    }

    void Update()
    {

        Vector3 Hip_reference_position = Hip_reference.transform.position           ;
        Vector3 Manikin_position = Hip_reference_position + Manikin_position_offset ;

        Quaternion Upper_leg_rotation_cube = Upper_leg_cube.rotation          ;
        Vector3 Upper_leg_EulerAngles = Upper_leg_rotation_cube.eulerAngles   ;

        Quaternion Lower_leg_rotation_cube = Lower_leg_cube.rotation          ;
        Vector3 Lower_leg_EulerAngles = Lower_leg_rotation_cube.eulerAngles   ;


        if (hasReadOffsets == false)
        {
            Vector3 Upper_leg_offsets = hip_desired_angles - Upper_leg_EulerAngles  ;
            Vector3 Lower_leg_offsets = knee_desired_angles - Lower_leg_EulerAngles ;
            hasReadOffsets = true ;
        }


        if (Manikin_body != null)
        {
            Manikin_body.transform.position = Manikin_position;
            Manikin_hip.transform.localEulerAngles = Upper_leg_EulerAngles + Upper_leg_offsets;
            //Manikin_knee.transform.localEulerAngles = Lower_leg_rotation_cube.eulerAngles + Lower_leg_offsets;

        }
    }
}