using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;
using System.IO.Ports           ;
using System.Threading          ;

public class NewObjectData : MonoBehaviour
{
    SerialPort stream = new SerialPort("COM7", 38400);
    private Thread serialThread ;
    private bool running = false;

    private string receivedString;
    private object dataLock = new object(); // for thread safety

    public int sensor1 ;
    public int sensor2 ;

    public GameObject handUpperLeg ;
    public GameObject handLowerLeg ;

    public float sensors_threshold ;


    void Start()
    {
        stream.Open() ;
        running = true;

        serialThread = new Thread(ReadSerial);
        serialThread.Start();

        if (handUpperLeg != null)
        {
            handUpperLeg.SetActive(false);
        }

    }

    void ReadSerial()
    {
        while (running)
        {
            try
            {
                string line = stream.ReadLine();
                lock (dataLock)
                {
                    receivedString = line;
                }
            }
            catch (System.Exception e)
            {
                Debug.LogWarning("Serial read error: " + e.Message);
            }
        }
    }

    void Update()
    {
        string line = null;

        lock (dataLock)
        {
            if (!string.IsNullOrEmpty(receivedString))
            {
                line = receivedString ;
                receivedString = null ; // clear it so we don't reuse old data
            }
        }

        if (line != null)
        {
            string[] data = line.Split(',');

            if (data.Length >= 2)
            {
                int.TryParse(data[0], out sensor1);
                int.TryParse(data[1], out sensor2);

                if (sensor1 > sensors_threshold && sensor2 < sensors_threshold)
                {
                    handUpperLeg.SetActive(true);
                    handUpperLeg.transform.localPosition = new Vector3(-0.09951805f, 0.2599763f, 0.02181772f);
                }

                else if (sensor2 > sensors_threshold && sensor1 < sensors_threshold)
                {
                    handUpperLeg.SetActive(true);
                    handUpperLeg.transform.localPosition = new Vector3(-0.09951805f, 0.2599763f, 0.02181772f);
                }

                else if (sensor1 > sensors_threshold && sensor2 > sensors_threshold)
                {
                    handUpperLeg.SetActive(true);
                    handUpperLeg.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                }

                else if (sensor1 < sensors_threshold && sensor2 < sensors_threshold)
                {
                    handUpperLeg.SetActive(false);
                }
            }
        }
    }

    void OnApplicationQuit()
    {
        running = false;
        if (serialThread != null && serialThread.IsAlive)
            serialThread.Join();

        if (stream.IsOpen)
            stream.Close();
    }
}