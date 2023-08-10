using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haptics_Pen_v3 : MonoBehaviour
{

    public GameObject apple;
    public GameObject cube_outter_apple;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = apple.GetComponent<Rigidbody>();
        Vector3 velocity = rb.velocity;
        Debug.Log("Changing haptics by velocity." + velocity);

        if (velocity.x > 0.0f || velocity.y > 0.0f || velocity.z > 0.0f)
        {
            Debug.Log("Changing haptics by velocity.");
            //cube_outter_apple.GetComponent<HapticEffectEditor>().HE.Frequency = velocity.x * 100f ;
            //cube_outter_apple.GetComponent<HapticEffect>().Gain = 0.5f;
        }
    }
}
