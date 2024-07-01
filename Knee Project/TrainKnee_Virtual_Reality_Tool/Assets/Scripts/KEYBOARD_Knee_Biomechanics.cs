
using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;

public class KEYBOARD_Knee_Biomechanics : MonoBehaviour
{
    
    public int selector      ;
    float turnspeed = 100.0f ;


    // Upper Extremity //

    public GameObject Upper_Extremity ;


    // Lower Extremity //

    public GameObject Right_leg  ;
    public GameObject Right_knee ;
    public GameObject Right_ankle;
    public GameObject Right_toes ;

    public GameObject Left_leg  ;
    public GameObject Left_knee ;
    public GameObject Left_ankle;
    public GameObject Left_toes ;

    
    void Start()
    {
        
    }

    
    void Update()
    {

        if (selector == 0)  // Controlling upper extremity
        {
            Upper_Extremity.transform.Rotate(Vector3.down*turnspeed*Input.GetAxis("Horizontal")*Time.deltaTime) ;
            Upper_Extremity.transform.Rotate(Vector3.right*turnspeed*Input.GetAxis("Vertical")*Time.deltaTime)  ;
        }


        if (selector == 1)  // Controlling right leg
        {

            if (Input.GetKey("up"))
            {
                Right_leg.transform.localEulerAngles += Vector3.left*turnspeed*Time.deltaTime ;
            }

            if (Input.GetKey("down"))
            {
                Right_leg.transform.localEulerAngles += Vector3.right*turnspeed*Time.deltaTime ;
            }

            if (Input.GetKey("right"))
            {
                Right_leg.transform.localEulerAngles += Vector3.down*turnspeed*Time.deltaTime ;
            }

            if (Input.GetKey("left"))
            {
                Right_leg.transform.localEulerAngles += Vector3.up*turnspeed*Time.deltaTime ;
            }

            if (Input.GetKey("a"))
            {
                Right_leg.transform.localEulerAngles += Vector3.forward*turnspeed*Time.deltaTime ;
            }

            if (Input.GetKey("s"))
            {
                Right_leg.transform.localEulerAngles += Vector3.back*turnspeed*Time.deltaTime ;
            }

        }


        if (selector == 2)  // Controlling right knee
        {

            if (Input.GetKey("up"))
            {
                Right_knee.transform.localEulerAngles += Vector3.right*turnspeed*Time.deltaTime ;
            }

            if (Input.GetKey("down"))
            {
                Right_knee.transform.localEulerAngles += Vector3.left*turnspeed*Time.deltaTime ;
            }

            if (Input.GetKey("right"))
            {
                Right_knee.transform.localEulerAngles += Vector3.up*turnspeed*Time.deltaTime ;
            }

            if (Input.GetKey("left"))
            {
                Right_knee.transform.localEulerAngles += Vector3.down*turnspeed*Time.deltaTime ;
            }

            if (Input.GetKey("a"))
            {
                Right_knee.transform.localEulerAngles += Vector3.forward*turnspeed*Time.deltaTime ;
            }

            if (Input.GetKey("s"))
            {
                Right_knee.transform.localEulerAngles += Vector3.back*turnspeed*Time.deltaTime ;
            }

        }




        if (selector == 5)  // Controlling left leg
        {

            if (Input.GetKey("up"))
            {
                Left_leg.transform.localEulerAngles += Vector3.left*turnspeed*Time.deltaTime ;
            }

            if (Input.GetKey("down"))
            {
                Left_leg.transform.localEulerAngles += Vector3.right*turnspeed*Time.deltaTime ;
            }

            if (Input.GetKey("right"))
            {
                Left_leg.transform.localEulerAngles += Vector3.down*turnspeed*Time.deltaTime ;
            }

            if (Input.GetKey("left"))
            {
                Left_leg.transform.localEulerAngles += Vector3.up*turnspeed*Time.deltaTime ;
            }

            if (Input.GetKey("a"))
            {
                Left_leg.transform.localEulerAngles += Vector3.forward*turnspeed*Time.deltaTime ;
            }

            if (Input.GetKey("s"))
            {
                Left_leg.transform.localEulerAngles += Vector3.back*turnspeed*Time.deltaTime ;
            }

        }
    }
}