
//using System.Collections;
//using System.Collections.Generic;

using UnityEngine   ;
using UnityEngine.UI;

public class Data_Display : MonoBehaviour
{

    public Transform cube_IMU  ;
    public Transform cube_Servo;
    public Transform cube_FSR  ;
    public Text angle_flexion_extension   ;
    public Text angle_abduction_adduction ;
    public Text angle_external_internal   ;
    public Text angle_servo_position      ;
    public Text force_FSR1                ;
    public Text force_FSR2                ;


    void Start()
    {
        
    }

    
    void Update()
    {
        angle_flexion_extension.text = cube_IMU.eulerAngles.x.ToString("0")   ;
        angle_abduction_adduction.text = cube_IMU.eulerAngles.z.ToString("0") ;
        angle_external_internal.text = cube_IMU.eulerAngles.y.ToString("0")   ;
        force_FSR1.text = cube_FSR.eulerAngles.x.ToString("0")                ;
        force_FSR2.text = cube_FSR.eulerAngles.x.ToString("0")                ;
        angle_servo_position.text = cube_Servo.eulerAngles.x.ToString("0")    ;

    }
}
