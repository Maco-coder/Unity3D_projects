
using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;
using UnityEngine.UI             ;
using System.IO.Ports            ;

public class MPU_Knee_Biomechanics : MonoBehaviour
{
    
    SerialPort stream = new SerialPort("COM3", 38400) ;

    public string receivedstring  ;
    public string[] data          ;
    public string[] data_received ;

    public GameObject Cube;
    public GameObject Leg ;

    public int x_value ;
    public int y_value ;
    public int z_value ;

    private int off_x ;
    private int off_y ;
    private int off_z ;


    void Start()
    {
        stream.Open();
        
        //Vector3 eulerRotation = Leg.transform.eulerAngles;
        Vector3 eulerRotation = Leg.transform.localEulerAngles;

        off_x = (int)eulerRotation.x ;
        off_y = (int)eulerRotation.y ;
        off_z = (int)eulerRotation.z ;

    }

    
    void Update()
    {

        receivedstring = stream.ReadLine();
        stream.BaseStream.Flush()         ;

        string[] data = receivedstring.Split(',');

        data_received[0] = data[0];
        int.TryParse(data[0], out x_value);

        data_received[1] = data[1];
        int.TryParse(data[1], out y_value);

        data_received[2] = data[2];
        int.TryParse(data[2], out z_value);


        //Cube.transform.rotation = Quaternion.Euler((x_value + off_x), (y_value + off_y), (z_value + off_z));
        
        //Leg.transform.rotation = Quaternion.Euler((x_value + off_x), (y_value + off_y), (z_value + off_z));

        Leg.transform.localEulerAngles = new Vector3((-x_value + off_x), (y_value + off_y), (-z_value + off_z));

    }
}