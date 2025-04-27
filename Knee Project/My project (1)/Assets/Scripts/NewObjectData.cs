using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class NewObjectData : MonoBehaviour
{
    SerialPort stream = new SerialPort("COM6", 38400);
    private Thread serialThread;
    private bool running = false;

    private string receivedString;
    private object dataLock = new object(); // for thread safety

    public int sensor1;
    public int sensor2;

    public GameObject handUpperLeg ;
    public GameObject handLowerLeg ;


    void Start()
    {
        stream.Open();
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
                line = receivedString;
                receivedString = null; // clear it so we don't reuse old data
            }
        }

        if (line != null)
        {
            string[] data = line.Split(',');

            if (data.Length >= 2)
            {
                int.TryParse(data[0], out sensor1);
                int.TryParse(data[1], out sensor2);

                if (sensor1 > 200 && sensor2 < 200)
                {
                    // TODO: Add logic when sensor1 > 200 and sensor2 < 200
                    handUpperLeg.SetActive(true);
                    handUpperLeg.transform.position = new Vector3(-0.18f, 1.035f, -3.70f);
                }

                else if (sensor2 > 200 && sensor1 < 200)
                {
                    // TODO: Add logic when sensor2 > 200 and sensor1 < 200
                    handUpperLeg.SetActive(true);
                    handUpperLeg.transform.position = new Vector3(-0.18f, 1.035f, -3.50f);

                }

                else if (sensor1 > 200 && sensor2 > 200)
                {
                    handUpperLeg.SetActive(true);
                    handUpperLeg.transform.position = new Vector3(0f, 1.50f, -3.70f);
                }

                else if (sensor1 < 200 && sensor2 < 200)
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