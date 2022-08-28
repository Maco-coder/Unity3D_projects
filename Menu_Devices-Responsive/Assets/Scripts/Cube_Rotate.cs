using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;

public class Cube_Rotate : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(Vector3.right * StoreVariables.VRcontroller_GRAB_pulse_time * Time.deltaTime)       ;
        transform.Rotate(Vector3.up * StoreVariables.VRcontroller_GRAB_pulse_frequency * Time.deltaTime)     ;
        transform.Rotate(Vector3.forward * StoreVariables.VRcontroller_GRAB_pulse_amplitude * Time.deltaTime);
    }
}
