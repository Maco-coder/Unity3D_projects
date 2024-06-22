using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;

public class Knee_Biomechanics : MonoBehaviour
{
    float turnspeed = 100.0f ;

    public GameObject Right_knee;
    public GameObject Left_knee ;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(Vector3.down*turnspeed*Input.GetAxis("Horizontal")*Time.deltaTime) ;
    }
}
