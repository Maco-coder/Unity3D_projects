
// HAPTICS_PEN_V1 //

using System.Collections          ;
using System.Collections.Generic  ;
using UnityEngine                 ;


public class Haptics_Pen_v1 : MonoBehaviour
{
    public GameObject apple             ;
    public GameObject cube_outter_apple ;
    public GameObject feedback_capsule  ;
    
    public static float velocity = 0f ;
    public static float value = 0f    ;


    void Start()
    {
        cube_outter_apple.SetActive(false);
        feedback_capsule.SetActive(false) ;
    }

    void Update()
    {

        Rigidbody rb = apple.GetComponent<Rigidbody>();
        velocity = rb.velocity.magnitude;
        Debug.Log("Changing haptics by velocity." + velocity);

        if (velocity > 0.01f)
        {
            Debug.Log("Changing haptics by velocity." + velocity);
            value = Mathf.Min(200 * velocity, 600f) ;
        }

        else
        {
            value = 0f;
        }
    }


    void OnJointBreak(float breakForce)
    {

        cube_outter_apple.SetActive(true);
        Debug.Log("The apple has been plucked from the tree!, force: " + breakForce);

    }


    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Grabber")
        {
            feedback_capsule.SetActive(true);
        }

    }


}
