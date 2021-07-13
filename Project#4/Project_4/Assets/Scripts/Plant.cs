using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;
using System.IO.Ports            ;


public class Plant : MonoBehaviour
{

    public float speed;
    private float amountToMove;

    SerialPort stream = new SerialPort("COM7", 115200);
    public string receivedString;
    public string[] data        ;
    public string[] dataReceived;
    public int[] sensors        ;


    void Start()
    {
        stream.Open();
    }


    void Update()
    {
        receivedString = stream.ReadLine();
        stream.BaseStream.Flush()         ;

        string[] data = receivedString.Split(',');
        if (data[0] != "" && data[1] != "")
        {
            dataReceived[0] =  data[0];
            dataReceived[1] =  data[1];
            stream.BaseStream.Flush();
        }

        sensors[0] = int.Parse(data[0]);
        sensors[1] = int.Parse(data[1]);

        //amountToMove = speed * Time.deltaTime;


        if (sensors[0] >= 250 && sensors[0] <= 300)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

    }

}
