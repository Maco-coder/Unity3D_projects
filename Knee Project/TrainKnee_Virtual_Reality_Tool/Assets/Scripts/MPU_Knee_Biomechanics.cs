
using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;
using UnityEngine.UI             ;
using System.IO.Ports            ;

public class MPU_Knee_Biomechanics : MonoBehaviour
{
    
    SerialPort stream = new SerialPort("COM3", 115200) ;

    public string receivedstring  ;
    public string[] data          ;
    public string[] data_received ;

    public GameObject Cube;

    public int x_value ;
    public int y_value ;
    public int z_value ;


    void Start()
    {
        stream.Open();
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
    }
}
