
using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;
using UnityEngine.UI             ;
using System.IO.Ports            ;


public class Sensors : MonoBehaviour
{

    SerialPort stream = new SerialPort("COM4", 38400);
    public string receivedstring  ;
    public string[] data          ;
    public string[] data_received ;

    // GameObjects //
    public Transform gameObject1 ;  // Cube_IMU
    public Transform gameObject2 ;  // Cube_FSR1
    public Transform gameObject3 ;  // Cube_FSR2
    public Transform gameObject4 ;  // Cube_Servo

    // Knee motion data //
    //public int Gyr1_X_value;
    //public int Gyr1_Y_value;
    //public int Gyr1_Z_value;

    //public int Gyr2_X_value;
    //public int Gyr2_Y_value;
    //public int Gyr2_Z_value;

    // Tension/Injury data //
    public int Servo_pos_value;

    // Force data //
    public int FSR1_value;
    public int FSR2_value;
    public int FSR3_value;

    // Displaying data //
    //public Transform cube_IMU;
    //public Transform cube_Servo;
    //public Transform cube_FSR;
    //public Text angle_flexion_extension;
    //public Text angle_abduction_adduction;
    //public Text angle_external_internal;
    public Text angle_servo_position;
    public Text force_FSR1  ;
    public Text force_FSR2  ;
    public Text force_FSR3  ;
    public Text grade_injury;


    void Start()
    {
        stream.Open();
    }

    
    void Update()
    {
        receivedstring = stream.ReadLine();
        stream.BaseStream.Flush();

        string[] data = receivedstring.Split(',');

        //if (data[0] != "" && data[1] != "" && data[2] != "" && data[3] != "" && data[4] != "" && data[5] != "")
        //{
        data_received[0] = data[0];
        int.TryParse(data[0], out Servo_pos_value);

        data_received[1] = data[1];
        int.TryParse(data[1], out FSR1_value);

        data_received[2] = data[2];
        int.TryParse(data[2], out FSR2_value);

        data_received[3] = data[3];
        int.TryParse(data[3], out FSR3_value);


        //data_received[3] = data[3];
        //int.TryParse(data[3], out Gyr1_X_value);

        //data_received[4] = data[4];
        //int.TryParse(data[4], out Gyr1_Y_value);

        //data_received[5] = data[5];
        //int.TryParse(data[5], out Gyr1_Z_value);

        //Vector3 to1 = new Vector3(Gyr1_X_value, Gyr1_Z_value, Gyr1_Y_value);
        //Vector3 to2 = new Vector3(FSR_value, 0, 0)                      ;
        //Vector3 to4 = new Vector3(Servo_pos_value, 0, 0)                ;

        //gameObject1.transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to1, Time.deltaTime * 100);
        //gameObject2.transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to2, Time.deltaTime * 100);
        //gameObject3.transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to3, Time.deltaTime * 100);
        //gameObject4.transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to4, Time.deltaTime * 100);

        //angle_flexion_extension.text = Gyr_X_value.ToString("0")  ;
        //angle_abduction_adduction.text = Gyr_Y_value.ToString("0");
        //angle_external_internal.text = Gyr_Z_value.ToString("0")  ;
        angle_servo_position.text = Servo_pos_value.ToString("0") ;
        force_FSR1.text = FSR1_value.ToString("0")                ;
        force_FSR2.text = FSR2_value.ToString("0")                ;
        force_FSR3.text = FSR3_value.ToString("0")                ;


        if (FSR1_value >= 0 && FSR1_value < 55)
        {
            force_FSR1.text = ("High pressure") ;
        }

        if (FSR1_value >= 55 && FSR1_value < 75)
        {
            force_FSR1.text = ("Medium pressure");
        }

        if (FSR1_value >= 75 && FSR1_value < 100)
        {
            force_FSR1.text = ("Low pressure");
        }

        if (FSR1_value >= 100)
        {
            force_FSR1.text = ("No pressure");
        }



        if (FSR2_value >= 0 && FSR2_value < 260)
        {
            force_FSR2.text = ("High pressure");
        }

        if (FSR2_value >= 260 && FSR2_value < 350)
        {
            force_FSR2.text = ("Medium pressure");
        }

        if (FSR2_value >= 350 && FSR2_value < 440)
        {
            force_FSR2.text = ("Low pressure");
        }

        if (FSR2_value >= 440)
        {
            force_FSR2.text = ("No pressure");
        }



        if (Servo_pos_value >= 0 && Servo_pos_value < 22)
        {
            grade_injury.text = ("Healthy");
        }

        if (Servo_pos_value >= 22 && Servo_pos_value < 40)
        {
            grade_injury.text = ("1");
        }

        if (Servo_pos_value >= 40 && Servo_pos_value < 60)
        {
            grade_injury.text = ("2");
        }

        if (Servo_pos_value >= 60)
        {
            grade_injury.text = ("3");
        }



    }

}
