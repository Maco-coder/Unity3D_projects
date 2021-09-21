using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;
using System.IO.Ports            ;

public class IMUdata1 : MonoBehaviour
{

    SerialPort stream = new SerialPort("COM7", 115200);
    public string receivedstring  ;
    public string[] data          ;
    public string[] data_received ;
    public int x_value1 ;
    public int y_value1 ;
    public int z_value1 ;
    //public int x_value2 ;
    //public int y_value2 ;
    //public int z_value2 ;


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
        //    data_received[0] = data[0];
        //    int.TryParse(data[0], out x_value1);

        //    data_received[1] = data[1];
        //    int.TryParse(data[1], out y_value1);

        //    data_received[2] = data[2];
        //    int.TryParse(data[2], out z_value1);

        //    data_received[3] = data[3];
        //    int.TryParse(data[3], out x_value2);

        //    data_received[4] = data[4];
        //    int.TryParse(data[4], out y_value2);

        //    data_received[5] = data[5];
        //    int.TryParse(data[5], out z_value2);

        //    //transform.Rotate(x_value, 0, 0, Space.Self);

        //    Vector3 to = new Vector3(x_value1, 0, y_value1);  // Raw values
        //    //Vector3 to = new Vector3((9 / 7) * x_value, 0, y_value - y_value);  // Mapped values
        //    transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime*100);

        //    stream.BaseStream.Flush() ;
        //}




        // FOR TESTING PURPOSES WITH ONLY ONE ACCELEROMETER //


        if (data[0] != "" && data[1] != "" && data[2] != "")
        {
            data_received[0] = data[0];
            int.TryParse(data[0], out x_value1);

            data_received[1] = data[1];
            int.TryParse(data[1], out y_value1);

            data_received[2] = data[2];
            int.TryParse(data[2], out z_value1);

            //transform.Rotate(x_value, 0, 0, Space.Self);

            //Vector3 to = new Vector3(x_value1, 0, y_value1);  // Raw values
            Vector3 to = new Vector3((9 / 7) * x_value1, 0, y_value1 - y_value1);  // Mapped values
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime * 100);
            

            stream.BaseStream.Flush();
        }




    }
}
