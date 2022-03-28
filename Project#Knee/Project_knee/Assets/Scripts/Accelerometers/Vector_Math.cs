
using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;
using UnityEngine.UI            ;
using System.IO.Ports           ;


public class Vector_Math : MonoBehaviour
{

    SerialPort stream = new SerialPort("COM3", 9600);
    public string receivedstring ;
    public string[] data         ;
    public string[] data_received;

    // GameObjects //
    public Transform gameObject1;  // Femur
    public Transform gameObject2;  // Tibia

    // Knee motion data //
    public int Gyr1_X_value;
    public int Gyr1_Y_value;
    public int Gyr1_Z_value;

    public int Gyr2_X_value;
    public int Gyr2_Y_value;
    public int Gyr2_Z_value;

    public int flexion_angle;


    void Start()
    {
        stream.Open();
    }


    void Update()
    {
        receivedstring = stream.ReadLine()       ;
        stream.BaseStream.Flush()                ;
        string[] data = receivedstring.Split(',');

        data_received[0] = data[0];
        int.TryParse(data[0], out Gyr1_X_value)  ;

        data_received[1] = data[1];
        int.TryParse(data[1], out Gyr1_Y_value)  ;

        data_received[2] = data[2];
        int.TryParse(data[2], out Gyr1_Z_value)  ;

        data_received[3] = data[3];
        int.TryParse(data[3], out Gyr2_X_value)  ;

        data_received[4] = data[4];
        int.TryParse(data[4], out Gyr2_Y_value)  ;

        data_received[5] = data[5];
        int.TryParse(data[5], out Gyr2_Z_value)  ;

        data_received[6] = data[6];
        int.TryParse(data[6], out flexion_angle) ;


        Vector3 to1 = new Vector3(Gyr1_X_value, 0, Gyr1_Y_value) ;
        Vector3 to2 = new Vector3(Gyr2_X_value, 0, Gyr2_Y_value) ;

        gameObject1.transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to1, Time.deltaTime * 100) ;
        gameObject2.transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to2, Time.deltaTime * 100) ;

    }
}
