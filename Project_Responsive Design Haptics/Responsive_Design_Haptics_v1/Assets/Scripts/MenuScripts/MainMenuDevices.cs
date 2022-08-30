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

    public bool SHAPE_roundVIVE;


    public float GRAB_vibration_gain       ;
    public float GRAB_vibration_magnitude  ;

    public float PLUCK_vibration_gain      ;
    public float PLUCK_vibration_magnitude ;

    public float SPRING_spring_gain        ;
    public float SPRING_spring_magnitude   ;

    public bool SHAPE_roundTOUCH ;


    public float GRAB_feedback  ;
    public float PLUCK_feedback ;
    public float SPRING_feedback;
    public bool SHAPE_roundPROPS;


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

        StoreVariables.SHAPE_VIVE_round = SHAPE_roundVIVE;
        
        SceneManager.LoadScene("VR Controller-scene");
    }


    public void Load3DTouchSystem()
    {
        StoreVariables.Touch_GRAB_vibration_gain = GRAB_vibration_gain            ;
        StoreVariables.Touch_GRAB_vibration_magnitude = GRAB_vibration_magnitude  ;
        
        StoreVariables.Touch_PLUCK_vibration_gain = PLUCK_vibration_gain          ;
        StoreVariables.Touch_PLUCK_vibration_magnitude = PLUCK_vibration_magnitude;

        StoreVariables.Touch_SPRING_spring_gain = SPRING_spring_gain              ;
        StoreVariables.Touch_SPRING_spring_magnitude = SPRING_spring_magnitude    ;

        StoreVariables.SHAPE_TOUCH_round = SHAPE_roundTOUCH ;
        
        SceneManager.LoadScene("3D touch-scene");
    }


    public void LoadHouseHoldProps()
    {
        StoreVariables.PROPS_GRAB_feedback = GRAB_feedback    ;
        StoreVariables.PROPS_PLUCK_feedback = PLUCK_feedback  ;
        StoreVariables.PROPS_SPRING_feedback = SPRING_feedback;
        StoreVariables.SHAPE_PROPS_round = SHAPE_roundPROPS   ;

        SceneManager.LoadScene("Household Props-scene");
    }

}
