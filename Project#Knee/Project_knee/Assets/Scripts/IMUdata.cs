using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;
using System.IO.Ports            ;

public class IMUdata : MonoBehaviour
{

    SerialPort stream = new SerialPort("COM3", 9600);
    public string receivedstring ;
    public GameObject IMU        ;
    public Vector3 rot1          ;
    public Vector3 rot2          ;
    public string[] data         ;
    public string[] data_received;


    void Start()
    {
        stream.Open();
    }

    
    void Update()
    {
        receivedstring = stream.ReadLine();
        stream.BaseStream.Flush();

        string[] data = receivedstring.Split(',');
        if (data[0] != "" && data[1] != "" && data[2] != "" && data[3] != "")
        {
            data_received[0] = data[0];
            data_received[1] = data[1];
            data_received[2] = data[2];
            data_received[3] = data[3];
            stream.BaseStream.Flush() ;
        }
    }
}
