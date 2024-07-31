
using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;
using UnityEngine.UI             ;
using System.IO.Ports            ;

public class ALL_MPU_Knee_Biomechanics : MonoBehaviour
{
    
    SerialPort stream = new SerialPort("COM3", 38400) ;

    public string receivedstring  ;
    public string[] data          ;
    public string[] data_received ;

    public GameObject Cube ;
    public GameObject Leg  ;
    public GameObject Knee ;

    // Hip (upper leg) Variables //
    public int x_value_hip ;
    public int y_value_hip ;
    public int z_value_hip ;

    private int off_x_hip ;
    private int off_y_hip ;
    private int off_z_hip ;


    // Knee (lower leg) Variables //
    public int x_value_knee ;
    public int y_value_knee ;
    public int z_value_knee ;

    private int off_x_knee ;
    private int off_y_knee ;
    private int off_z_knee ;



    void Start()
    {
        stream.Open();
        
        //Vector3 eulerRotation = Leg.transform.eulerAngles;
        Vector3 eulerRotation_hip =  Leg.transform.localEulerAngles  ;
        Vector3 eulerRotation_knee = Knee.transform.localEulerAngles ;

        off_x_hip = (int)eulerRotation_hip.x ;
        off_y_hip = (int)eulerRotation_hip.y ;
        off_z_hip = (int)eulerRotation_hip.z ;

        off_x_knee = (int)eulerRotation_knee.x ;
        off_y_knee = (int)eulerRotation_knee.y ;
        off_z_knee = (int)eulerRotation_knee.z ;

    }

    
    void Update()
    {

        receivedstring = stream.ReadLine();
        stream.BaseStream.Flush()         ;

        string[] data = receivedstring.Split(',');

        data_received[0] = data[0];
        int.TryParse(data[0], out x_value_hip);

        data_received[1] = data[1];
        int.TryParse(data[1], out y_value_hip);

        data_received[2] = data[2];
        int.TryParse(data[2], out z_value_hip);


        //Cube.transform.rotation = Quaternion.Euler((x_value + off_x), (y_value + off_y), (z_value + off_z));
        //Leg.transform.rotation = Quaternion.Euler((x_value + off_x), (y_value + off_y), (z_value + off_z));

        Leg.transform.localEulerAngles = new Vector3((-x_value_hip + off_x_hip), (y_value_hip + off_y_hip), (-z_value_hip + off_z_hip)) ;

        //Knee.transform.localEulerAngles = new Vector3((-x_value + off_x), (y_value + off_y), (-z_value + off_z));

    }
}