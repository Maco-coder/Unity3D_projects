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

        if (StoreVariables.VRcontroller_GRAB_pulse_time > 0 && StoreVariables.VRcontroller_GRAB_pulse_frequency > 0 && StoreVariables.VRcontroller_GRAB_pulse_amplitude > 0)
        {
            GRABVR = 1;
        }

        if (StoreVariables.VRcontroller_PLUCK_pulse_time > 0 && StoreVariables.VRcontroller_PLUCK_pulse_frequency > 0 && StoreVariables.VRcontroller_PLUCK_pulse_amplitude > 0)
        {
            PLUCKVR = 1;
        }

        if (StoreVariables.VRcontroller_SPRING_pulse_time > 0 && StoreVariables.VRcontroller_SPRING_pulse_frequency > 0 && StoreVariables.VRcontroller_SPRING_pulse_amplitude > 0)
        {
            SPRINGVR = 1;
        }

        if (StoreVariables.SHAPE_VIVE_round == true)
        {
            SHAPEVR = 1;
        }

        VRcontroller_compatibility = GRABVR + PLUCKVR + SPRINGVR + SHAPEVR;

        if (VRcontroller_compatibility == 0)
        {
            TextVR.text = "not supported"          ;
            ButtonVRcontroller.interactable = false;
        }

        if (VRcontroller_compatibility == 1)
        {
            TextVR.text = "minimally supported"   ;
            ButtonVRcontroller.interactable = true;
        }

        if (VRcontroller_compatibility == 2 ||  VRcontroller_compatibility == 3 )
        {
            TextVR.text = "partially supported"   ;
            ButtonVRcontroller.interactable = true;
        }

        if (VRcontroller_compatibility == 4)
        {
            TextVR.text = "fully supported"       ;
            ButtonVRcontroller.interactable = true;
        }


        
        // 3D TOUCH SYSTEM SCAN //

        if (StoreVariables.Touch_GRAB_vibration_gain > 0 && StoreVariables.Touch_GRAB_vibration_magnitude > 0)
        {
            GRABTOUCH = 1;
        }

        if (StoreVariables.Touch_PLUCK_vibration_gain > 0 && StoreVariables.Touch_PLUCK_vibration_magnitude > 0)
        {
            PLUCKTOUCH = 1;
        }

        if (StoreVariables.Touch_SPRING_spring_gain > 0 && StoreVariables.Touch_SPRING_spring_magnitude > 0)
        {
            SPRINGTOUCH = 1;
        }

        if (StoreVariables.SHAPE_TOUCH_round == true)
        {
            SHAPETOUCH = 1;
        }

        Touch_compatibility = GRABTOUCH + PLUCKTOUCH + SPRINGTOUCH + SHAPETOUCH;

        if (Touch_compatibility == 0)
        {
            TextTOUCH.text = "not supported"  ;
            Button3DTouch.interactable = false;
        }

        if (Touch_compatibility == 1)
        {
            TextVR.text = "minimally supported";
            Button3DTouch.interactable = true  ;
        }

        if (Touch_compatibility == 2 ||  VRcontroller_compatibility == 3 )
        {
            TextVR.text = "partially supported";
            Button3DTouch.interactable = true ;
        }

        if (Touch_compatibility == 4)
        {
            TextVR.text = "fully supported"  ;
            Button3DTouch.interactable = true;
        }



        // HOUSEHOLD PROPS SCAN //

        if (StoreVariables.PROPS_GRAB_feedback > 0)
        {
            GRABprops = 1;
        }

        if (StoreVariables.PROPS_PLUCK_feedback > 0)
        {
            PLUCKprops = 1;
        }

        if (StoreVariables.PROPS_SPRING_feedback > 0)
        {
            SPRINGprops = 1;
        }

        if (SStoreVariables.SHAPE_PROPS_round == true)
        {
            SHAPEprops = 1;
        }

        Props_compatibility = GRABprops + PLUCKprops + SPRINGprops + SHAPEprops;

        if (Touch_compatibility == 0)
        {
            Textprops.text = "not supported"  ;
            ButtonProps.interactable = false;
        }

        if (Touch_compatibility == 1)
        {
            Textprops.text = "minimally supported";
            ButtonProps.interactable = true  ;
        }

        if (Touch_compatibility == 2 ||  VRcontroller_compatibility == 3 )
        {
            Textprops.text = "partially supported";
            ButtonProps.interactable = true ;
        }

        if (Touch_compatibility == 4)
        {
            Textprops.text = "fully supported"  ;
            ButtonProps.interactable = true;
        }
    }
}
