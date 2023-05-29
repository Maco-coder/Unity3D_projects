using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;
using System.IO.Ports            ;


public class Saving_Data : MonoBehaviour
{

    SerialPort serialPort        ;
    string filePath = "data.txt" ;

    void Start()
    {
        serialPort = new SerialPort("COM4", 34800);
        serialPort.Open()                         ;
    }

    void Update()
    {
        if (serialPort.IsOpen && serialPort.BytesToRead > 0)
        {
            string receivedData = serialPort.ReadLine() ;
            System.IO.File.AppendAllText(filePath, receivedData + "\n");
        }
    }

    void OnDestroy()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}
