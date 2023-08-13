
// HAPTICS_PEN_V3 //

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haptics_Pen_v3 : MonoBehaviour
{

    public GameObject apple;
    public GameObject cube_outter_apple;
    
    public static float velocity = 0f  ;

    public static float value = 0f   ;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        Rigidbody rb = apple.GetComponent<Rigidbody>();
        velocity = rb.velocity.magnitude;
        Debug.Log("Changing haptics by velocity." + velocity);

        if (velocity > 0.01f)
        {
            Debug.Log("Changing haptics by velocity.");
            value = Mathf.Min(200 * velocity, 600f) ;
            //cube_outter_apple.GetComponent<HapticEffectEditor>().HE.Frequency = velocity.x * 100f ;
            //cube_outter_apple.GetComponent<HapticEffect>().Gain = 0.5f;
        }

        else
        {
            value = 0f;
        }


    }

    //void OnCollisionEnter(Collision collision) 
    //{
    //    if (collision.gameObject.name == "Grabber" && velocity == 0.0f)
    //    {
    //        Debug.Log("Entered collision");
    //        velocity = 800.0f;
    //    }
    //}

    //void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.name == "Grabber" && velocity == 800.0f)
    //    {
    //        Debug.Log("Exit collision");
    //        velocity = 0.0f;
    //    }
    //}

}