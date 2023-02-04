
using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;
using UnityEngine.UI            ;

public class Sliders : MonoBehaviour
{
    
    public Slider servomotor;
    private int servo_value = 0 ;
    public int max_servo = 180  ;
    
    //private Slider Upper  ;
    //private Slider Lower1 ;
    //private Slider Lower2 ;

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (servo_value <= max_servo)
            {
                servo_value++ ;
                servomotor.value = servo_value ;
            }
        } 
    }
}
