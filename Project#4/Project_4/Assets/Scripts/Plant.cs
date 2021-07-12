using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;
using System.IO.Ports            ;


public class Plant : MonoBehaviour
{

    public float speed;
    SerialPort sp = new SerialPort("COM3", 9600);


    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;
    }


    void Update()
    {
        if (sp.IsOpen)
        {
            try
            {
                print(sp.ReadByte());
            }
            catch (System.Exception)
            {

            }
        }

    }

    void MoveObject(int direction)
    {

    }
}
