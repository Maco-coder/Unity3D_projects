
using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;
using UnityEngine.UI             ;
using System.IO.Ports            ;


public class Sensors : MonoBehaviour
{

    SerialPort stream = new SerialPort("COM8", 38400);
    public string receivedstring  ;
    public string[] data          ;
    public string[] data_received ;

    // Tension/Injury data //
    public int Servomotor_value;

    public GameObject DIAL ;
    public int DIAL_value  ;

    // Force data //
    public int Upper_value ;
    public int Lower1_value;
    public int Lower2_value;

    // Displaying data //
    public Text angle_servo_position;
    public Text force_Upper         ;
    public Text force_Lower1        ;
    public Text force_Lower2        ;
    public Text grade_injury        ;

    public Slider servomotor;
    public int max_servo    ;

    public Slider FSRupper  ;
    public int max_FSRupper ;
    
    public Slider FSRlower1  ;
    public int max_FSRlower1 ;

    public Slider FSRlower2  ;
    public int max_FSRlower2 ;



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

        //angle_servo_position.text = Servomotor_value.ToString("0");
        //force_Upper.text = Upper_value.ToString("0")              ;
        //force_Lower1.text = Lower1_value.ToString("0")            ;
        //force_Lower2.text = Lower2_value.ToString("0")            ;

        servomotor.value = Servomotor_value;
        FSRupper.value = Upper_value       ;
        FSRlower1.value = Lower1_value     ;
        FSRlower2.value = Lower2_value     ;

        DIAL.transform.Rotate(0, 0, (Servomotor_value / 1.42f), Space.Self);

    }

}