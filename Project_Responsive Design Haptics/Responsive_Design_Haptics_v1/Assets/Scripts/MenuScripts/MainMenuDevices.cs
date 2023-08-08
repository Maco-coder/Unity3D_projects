
using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;
using UnityEngine.UI             ;
using UnityEngine.SceneManagement;


public class MainMenuDevices : MonoBehaviour
{

    public Button ButtonVRcontroller       ;
    private int VRcontroller_compatibility ;
    private int GRABVR  ;
    private int PLUCKVR ;
    private int SPRINGVR;
    private int SHAPEVR ;
    public Text TextVR  ;

    public Button Button3DTouch     ;
    private int Touch_compatibility ;
    private int GRABTOUCH  ;
    private int PLUCKTOUCH ;
    private int SPRINGTOUCH;
    private int SHAPETOUCH ;
    public Text TextTOUCH  ;

    public Button ButtonProps ;
    private int Props_compatibility ;
    private int GRABprops;
    private int PLUCKprops;
    private int SPRINGprops;
    private int SHAPEprops;
    public Text Textprops;

    
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
        
        SceneManager.LoadScene("3D Touch-Scene");
    }


    public void LoadHouseHoldProps()
    {
        StoreVariables.PROPS_GRAB_feedback = GRAB_feedback    ;
        StoreVariables.PROPS_PLUCK_feedback = PLUCK_feedback  ;
        StoreVariables.PROPS_SPRING_feedback = SPRING_feedback;
        StoreVariables.SHAPE_PROPS_round = SHAPE_roundPROPS   ;

        SceneManager.LoadScene("FruitPicker-scene");
    }


    void Update()
    {

        // VR CONTROLLER SCAN //

        if (GRAB_pulse_time > 0 && GRAB_pulse_frequency > 0 && GRAB_pulse_amplitude > 0)
        {
            GRABVR = 1;
        }

        if (PLUCK_pulse_time > 0 && PLUCK_pulse_frequency > 0 && PLUCK_pulse_amplitude > 0)
        {
            PLUCKVR = 1;
        }

        if (SPRING_pulse_time > 0 && SPRING_pulse_frequency > 0 && SPRING_pulse_amplitude > 0)
        {
            SPRINGVR = 1;
        }

        if (SHAPE_roundVIVE == true)
        {
            SHAPEVR = 1;
        }

        VRcontroller_compatibility = GRABVR + PLUCKVR + SPRINGVR + SHAPEVR;

        if (VRcontroller_compatibility == 0)
        {
            TextVR.text = "not supported"          ;
            TextVR.color= new Color(1, 0, 0, 1)    ;
            ButtonVRcontroller.interactable = false;
        }

        if (VRcontroller_compatibility == 1)
        {
            TextVR.text = "minimally supported"             ;
            TextVR.color= new Color(1.0f, 0.65f, 0.0f, 1.0f);
            ButtonVRcontroller.interactable = true          ;
        }

        if (VRcontroller_compatibility == 2 ||  VRcontroller_compatibility == 3 )
        {
            TextVR.text = "partially supported"            ;
            TextVR.color= new Color(0.5f, 1.0f, 0.3f, 1.0f);
            ButtonVRcontroller.interactable = true         ;
        }

        if (VRcontroller_compatibility == 4)
        {
            TextVR.text = "fully supported"       ;
            TextVR.color= new Color(0, 1, 0, 1)   ;
            ButtonVRcontroller.interactable = true;
        }



        // 3D TOUCH SYSTEM SCAN //

        if (GRAB_vibration_gain > 0 && GRAB_vibration_magnitude > 0)
        {
            GRABTOUCH = 1;
        }

        if (PLUCK_vibration_gain > 0 && PLUCK_vibration_magnitude > 0)
        {
            PLUCKTOUCH = 1;
        }

        if (SPRING_spring_gain > 0 && SPRING_spring_magnitude > 0)
        {
            SPRINGTOUCH = 1;
        }

        if (SHAPE_roundTOUCH == true)
        {
            SHAPETOUCH = 1;
        }

        Touch_compatibility = GRABTOUCH + PLUCKTOUCH + SPRINGTOUCH + SHAPETOUCH;

        if (Touch_compatibility == 0)
        {
            TextTOUCH.text = "not supported"      ;
            TextTOUCH.color= new Color(1, 0, 0, 1);
            Button3DTouch.interactable = false    ;
        }

        if (Touch_compatibility == 1)
        {
            TextTOUCH.text = "minimally supported"             ;
            TextTOUCH.color= new Color(1.0f, 0.65f, 0.0f, 1.0f);
            Button3DTouch.interactable = true                  ;
        }

        if (Touch_compatibility == 2 ||  VRcontroller_compatibility == 3 )
        {
            TextTOUCH.text = "partially supported"            ;
            TextTOUCH.color= new Color(0.5f, 1.0f, 0.3f, 1.0f);
            Button3DTouch.interactable = true                 ;
        }

        if (Touch_compatibility == 4)
        {
            TextTOUCH.text = "fully supported"    ;
            TextTOUCH.color= new Color(0, 1, 0, 1);
            Button3DTouch.interactable = true     ;
        }



        // HOUSEHOLD PROPS SCAN //

        if (GRAB_feedback > 0)
        {
            GRABprops = 1;
        }

        if (PLUCK_feedback > 0)
        {
            PLUCKprops = 1;
        }

        if (SPRING_feedback > 0)
        {
            SPRINGprops = 1;
        }

        if (SHAPE_roundPROPS == true)
        {
            SHAPEprops = 1;
        }

        Props_compatibility = GRABprops + PLUCKprops + SPRINGprops + SHAPEprops;

        if (Props_compatibility == 0)
        {
            Textprops.text = "not supported"      ;
            Textprops.color= new Color(1, 0, 0, 1);
            ButtonProps.interactable = false      ;
        }

        if (Props_compatibility == 1)
        {
            Textprops.text = "minimally supported"             ;
            Textprops.color= new Color(1.0f, 0.65f, 0.0f, 1.0f);
            ButtonProps.interactable = true                    ;
        }

        if (Props_compatibility == 2 ||  Props_compatibility == 3 )
        {
            Textprops.text = "partially supported"            ;
            Textprops.color= new Color(0.5f, 1.0f, 0.3f, 1.0f);
            ButtonProps.interactable = true                   ;
        }

        if (Props_compatibility == 4)
        {
            Textprops.text = "fully supported"    ;
            Textprops.color= new Color(0, 1, 0, 1);
            ButtonProps.interactable = true       ;
        }
    }
}
