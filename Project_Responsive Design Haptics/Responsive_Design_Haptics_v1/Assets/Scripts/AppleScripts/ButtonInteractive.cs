using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;
using UnityEngine.UI            ;


public class ButtonInteractive : MonoBehaviour
{
    
    public Button ButtonVRcontroller ;
    private int VRcontroller_compatibility ;
    private int GRABVR  ;
    private int PLUCKVR ;
    private int SPRINGVR;
    private int SHAPEVR ;
    public Text TextVR  ;

    public Button Button3DTouch ;
    private int Touch_compatibility ;
    private int GRABTOUCH  ;
    private int PLUCKTOUCH ;
    private int SPRINGTOUCH;
    private int SHAPETOUCH ;
    public Text TextTOUCH;

    public Button ButtonProps ;
    private int Props_compatibility ;
    private int GRABprops;
    private int PLUCKprops;
    private int SPRINGprops;
    private int SHAPEprops;
    public Text Textprops;
    
    
    
    void Update()
    {

        // VR CONTROLLER SCAN //

        if (StoreVariables.VRcontroller_GRAB_pulse_time == 0 && StoreVariables.VRcontroller_GRAB_pulse_frequency == 0 && StoreVariables.VRcontroller_GRAB_pulse_amplitude == 0)
        {
            //ButtonVRcontroller.interactable = false;
            var1VR = 1;

        }

        if (StoreVariables.VRcontroller_PLUCK_pulse_time == 0 && StoreVariables.VRcontroller_PLUCK_pulse_frequency == 0 && StoreVariables.VRcontroller_PLUCK_pulse_amplitude == 0)
        {
            PLUCKVR = 1;
        }

        if (StoreVariables.VRcontroller_SPRING_pulse_time == 0 && StoreVariables.VRcontroller_SPRING_pulse_frequency == 0 && StoreVariables.VRcontroller_SPRING_pulse_amplitude == 0)
        {
            //ButtonVRcontroller.interactable = true;
        }

        
        
        
        // 3D TOUCH SYSTEM SCAN //

        if (StoreVariables.Touch_GRAB_vibration_gain == 0 && StoreVariables.Touch_GRAB_vibration_magnitude == 0)
        {
            //ButtonVRcontroller.interactable = false;
        }

        if (StoreVariables.Touch_PLUCK_vibration_gain == 0 && StoreVariables.Touch_PLUCK_vibration_magnitude == 0)
        {
            //ButtonVRcontroller.interactable = true;
        }

        if (StoreVariables.Touch_SPRING_spring_gain == 0 && StoreVariables.Touch_SPRING_spring_magnitude == 0)
        {
            //ButtonVRcontroller.interactable = true;
        }

        if (StoreVariables.SHAPE_TOUCH_round == false)
        {

        }

        
    }
}
