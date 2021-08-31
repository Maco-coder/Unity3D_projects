using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;
using System.IO.Ports            ;

public class IMUdata2 : MonoBehaviour
{

    SerialPort stream = new SerialPort("COM7", 115200);
    public string receivedstring ;
    //public GameObject IMU        ;
    //public Vector3 rot1          ;
    //public Vector3 rot2          ;
    public string[] data         ;
    public string[] data_received;
    int x_value;
    int y_value;
    int z_value;


    void Start()
    {
        stream.Open();
    }

    
    void Update()
    {
        receivedstring = stream.ReadLine();
        stream.BaseStream.Flush();

        string[] data = receivedstring.Split(',');
        if (data[0] != "" && data[1] != "" && data[2] != "")
        {
            data_received[0] = data[0];
            int.TryParse(data[0], out x_value);

            data_received[1] = data[1];
            int.TryParse(data[1], out y_value);

            data_received[2] = data[2];
            int.TryParse(data[2], out z_value);

            //transform.Rotate(x_value, 0, 0, Space.Self);

            Vector3 to = new Vector3(x_value, 0, y_value);  // Raw values
            //Vector3 to = new Vector3((9 / 7) * x_value, 0, y_value - y_value);  // Mapped values
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime*100);

            stream.BaseStream.Flush() ;
        }
    }
}
