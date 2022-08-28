using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;
using UnityEngine.UI             ;
using UnityEngine.SceneManagement;


public class MainMenuDevices : MonoBehaviour
{
    
    public float GRAB_pulse_time      ;
    public float GRAB_pulse_frequency ;
    public float GRAB_pulse_amplitude ;

    public float PLUCK_pulse_time      ;
    public float PLUCK_pulse_frequency ;
    public float PLUCK_pulse_amplitude ;

    public float SPRING_pulse_time      ;
    public float SPRING_pulse_frequency ;
    public float SPRING_pulse_amplitude ;

    public int SHAPE_VIVE;


    public float GRAB_vibration_gain       ;
    public float GRAB_vibration_magnitude  ;

    public float PLUCK_vibration_gain      ;
    public float PLUCK_vibration_magnitude ;

    public float SPRING_spring_gain        ;
    public float SPRING_spring_magnitude   ;

    public int SHAPE_3DTOUCH;


    public void LoadVRController()
    {
        StoreVariables.VRcontroller_GRAB_pulse_time = GRAB_pulse_time          ;
        StoreVariables.VRcontroller_GRAB_pulse_frequency = GRAB_pulse_frequency;
        StoreVariables.VRcontroller_GRAB_pulse_amplitude = GRAB_pulse_amplitude;

        StoreVariables.VRcontroller_PLUCK_pulse_time = PLUCK_pulse_time          ;
        StoreVariables.VRcontroller_PLUCK_pulse_frequency = PLUCK_pulse_frequency;
        StoreVariables.VRcontroller_PLUCK_pulse_amplitude = PLUCK_pulse_amplitude;

        StoreVariables.VRcontroller_SPRING_pulse_time = SPRING_pulse_time          ;
        StoreVariables.VRcontroller_SPRING_pulse_frequency = SPRING_pulse_frequency;
        StoreVariables.VRcontroller_SPRING_pulse_amplitude = SPRING_pulse_amplitude;

        StoreVariables.VRcontroller_SHAPE_VIVE = SHAPE_VIVE;
        
        SceneManager.LoadScene("AppleGame_with_VIVE_controller");
    }


    public void Load3DTouchSystem()
    {
        StoreVariables.Touch_GRAB_vibration_gain = GRAB_vibration_gain            ;
        StoreVariables.Touch_GRAB_vibration_magnitude = GRAB_vibration_magnitude  ;
        
        StoreVariables.Touch_PLUCK_vibration_gain = PLUCK_vibration_gain          ;
        StoreVariables.Touch_PLUCK_vibration_magnitude = PLUCK_vibration_magnitude;

        StoreVariables.Touch_SPRING_spring_gain = SPRING_spring_gain              ;
        StoreVariables.Touch_SPRING_spring_gain = SPRING_spring_magnitude         ;

        StoreVariables.VRcontroller_SHAPE_VIVE = SHAPE_3DTOUCH;
        
        SceneManager.LoadScene("AppleGame_with_3D_Touch");
    }
}
