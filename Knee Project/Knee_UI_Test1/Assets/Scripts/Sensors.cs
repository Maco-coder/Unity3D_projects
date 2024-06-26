
using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;
using UnityEngine.UI             ;
using System.IO.Ports            ;


public class Sensors : MonoBehaviour
{

    SerialPort stream = new SerialPort("COM4", 38400) ;
    
    string filePath = "Assets/SavedData/savedData.txt";
    string filePath_grades = "Assets/SavedData/Grades.txt";
    string filePath_staircase = "Assets/SavedData/Staircase.txt";
    //string filePath = "Assets/SavedData/Oliver.txt";
    //string filePath = "Assets/SavedData/Mark.txt";

    public string receivedstring  ;
    public string[] data          ;
    public string[] data_received ;

    // Tension/Injury data //
    public int tension_gauge;

    public GameObject DIAL ;
    public int DIAL_value  ;

    // Force data //
    public int Upper_value ;
    public int Lower1_value;
    public int Lower2_value;
    public int Lower3_value;

    // Displaying data //
    public Text tension_sensor ;
    public Text grade_injury   ;
    //public Text force_Upper  ;
    //public Text force_Lower1 ;
    //public Text force_Lower2 ;

    public Slider Tension  ;
    public int max_tension ;

    public Slider FSRUpper  ;
    public int max_FSRupper ;
    
    public Slider FSRlower1  ;
    public int max_FSRlower1 ;

    public Slider FSRlower2  ;
    public int max_FSRlower2 ;

    public Slider FSRlower3  ;
    public int max_FSRlower3 ;

    bool read_tension = true ;

    public GameObject ON_indicator  ;
    public GameObject OFF_indicator ;


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
        int.TryParse(data[0], out tension_gauge);
        //Debug.Log(tension_gauge);

        data_received[1] = data[1];
        int.TryParse(data[1], out Upper_value);

        data_received[2] = data[2];
        int.TryParse(data[2], out Lower3_value);

        data_received[3] = data[3];
        int.TryParse(data[3], out Lower2_value);

        data_received[4] = data[4];
        int.TryParse(data[4], out Lower1_value);

        tension_sensor.text = tension_gauge.ToString();
        //force_Upper.text = Upper_value.ToString("0")   ;
        //force_Lower1.text = Lower1_value.ToString("0") ;
        //force_Lower2.text = Lower2_value.ToString("0") ;

        Tension.value = tension_gauge ;
        FSRUpper.value = Upper_value  ;
        FSRlower1.value = Lower1_value ;
        FSRlower2.value = Lower2_value ;
        FSRlower3.value = Lower3_value ;


//        if (Input.GetKeyDown("s"))
//        {   
//            read_tension = !read_tension             ;
//            print("Tension reading " + read_tension) ;
//        }

//        if (read_tension == true)
//        {
//            data_received[0] = data[0]               ;
//            int.TryParse(data[0], out tension_gauge) ;
//            Tension.value = tension_gauge            ;
//            ON_indicator.SetActive(true)             ;
//            OFF_indicator.SetActive(false)           ;
//        }

//        if (read_tension == false)
//        {
//            data[0] = "0"                 ;
//            Tension.value = tension_gauge ;
//            ON_indicator.SetActive(false) ;
//            OFF_indicator.SetActive(true) ;
//       }


//        if ((tension_gauge) >= 70 && (tension_gauge) <90)
//        {
//            grade_injury.text = ("healthy");
//        }

//        if ((tension_gauge) >= 90 && (tension_gauge) < 120)
//        {
//            grade_injury.text = ("1");
//        }

//       if ((tension_gauge) >= 120 && (tension_gauge) < 150)
//        {
//            grade_injury.text = ("2");
//        }
        
//        if ((tension_gauge) >= 150)
//        {
//            grade_injury.text = ("3");
//        }

//        System.IO.File.AppendAllText(filePath, receivedstring + "\n");


//       if (Input.GetKeyDown("space"))
//        {
//            print("space key has been pressed")                              ;
//            System.IO.File.AppendAllText(filePath_staircase, data[0] + "\n") ;
//        }

//        if (Input.GetKeyDown("1"))
//        {
//            print("A grade 1 has been sensed")                      ;
//            System.IO.File.AppendAllText(filePath_grades, 1 + "\n") ;
//        }

//        if (Input.GetKeyDown("2"))
//        {
//            print("A grade 2 has been sensed")                      ;
//            System.IO.File.AppendAllText(filePath_grades, 2 + "\n") ;
//        }

//        if (Input.GetKeyDown("3"))
//        {
//            print("A grade 3 has been sensed")                      ;
//            System.IO.File.AppendAllText(filePath_grades, 3 + "\n") ;
//       }

//        if (Input.GetKeyDown("h"))
//        {
//            print("A healthy knee has been sensed")                 ;
//            System.IO.File.AppendAllText(filePath_grades, 0 + "\n") ;
//       }

    }

}