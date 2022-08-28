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

    public float vibration_gain      ;
    public float vibration_magnitude ;
    public float spring_gain         ;
    public float spring_magnitude    ;


    public void LoadVRController()
    {
        StoreVariables.VRcontroller_GRAB_pulse_time = GRAB_pulse_time          ;
        StoreVariables.VRcontroller_GRAB_pulse_frequency = GRAB_pulse_frequency;
        StoreVariables.VRcontroller_GRAB_pulse_amplitude = GRAB_pulse_amplitude;
        
        SceneManager.LoadScene("AppleGame_with_VR_controller");
    }


    public void Load3DTouchSystem()
    {

        StoreVariables.Touch_vibration_gain = vibration_gain          ;
        StoreVariables.Touch_vibration_magnitude = vibration_magnitude;
        StoreVariables.Touch_spring_gain = spring_gain                ;
        StoreVariables.Touch_spring_gain = spring_magnitude           ;
        
        SceneManager.LoadScene("AppleGame_with_3D_Touch");
    }
}
