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
    public Transform gameObject1 ;  // Servomotor slider
    public Transform gameObject2 ;  // Upper Leg Slider
    public Transform gameObject3 ;  // Lower Leg1 Slider
    public Transform gameObject4 ;  // Lower Leg2 Slider 

    // Tension/Injury data //
    public int Servomotor_value;

    // Force data //
    public int Upper_value ;
    public int Lower1_value;
    public int Lower2_value;

    // Displaying data //
    //public Transform cube_IMU;
    //public Transform cube_Servo;
    //public Transform cube_FSR;
    public Text angle_servo_position;
    public Text force_Upper  ;
    public Text force_Lower1 ;
    public Text force_Lower2 ;
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
        int.TryParse(data[0], out Servomotor_value);

        data_received[1] = data[1];
        int.TryParse(data[1], out Upper_value);

        data_received[2] = data[2];
        int.TryParse(data[2], out Lower1_value);

        data_received[3] = data[3];
        int.TryParse(data[3], out Lower2_value);

        angle_servo_position.text = Servomotor_value.ToString("0") ;
        force_Upper.text = Upper_value.ToString("0")              ;
        force_Lower1.text = Lower1_value.ToString("0")            ;
        force_Lower2.text = Lower2_value.ToString("0")            ;


        //if (FSR1_value >= 0 && FSR1_value < 55)
        //{
        //    force_FSR1.text = ("High pressure") ;
        //}

        //if (FSR1_value >= 55 && FSR1_value < 75)
        //{
        //   force_FSR1.text = ("Medium pressure");
        //}

        //if (FSR1_value >= 75 && FSR1_value < 100)
        //{
        //    force_FSR1.text = ("Low pressure");
        //}

        //if (FSR1_value >= 100)
        //{
        //    force_FSR1.text = ("No pressure");
        //}



        //if (FSR2_value >= 0 && FSR2_value < 260)
        //{
        //    force_FSR2.text = ("High pressure");
        //}

        //if (FSR2_value >= 260 && FSR2_value < 350)
        //{
        //    force_FSR2.text = ("Medium pressure");
        //}

        //if (FSR2_value >= 350 && FSR2_value < 440)
        //{
        //    force_FSR2.text = ("Low pressure");
        //}

        //if (FSR2_value >= 440)
        //{
        //    force_FSR2.text = ("No pressure");
        //}



        //if (Servo_pos_value >= 0 && Servo_pos_value < 22)
        //{
        //    grade_injury.text = ("Healthy");
        //}

        //if (Servo_pos_value >= 22 && Servo_pos_value < 40)
        //{
        //    grade_injury.text = ("1");
        //}

        //if (Servo_pos_value >= 40 && Servo_pos_value < 60)
        //{
        //    grade_injury.text = ("2");
        //}

        //if (Servo_pos_value >= 60)
        //{
        //    grade_injury.text = ("3");
        //}



    }

}