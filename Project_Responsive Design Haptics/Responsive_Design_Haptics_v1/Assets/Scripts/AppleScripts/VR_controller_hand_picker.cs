using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_controller_hand_picker : MonoBehaviour
{

    public GameObject Right_Hand_Controller;

    
    void Start()
    {
        
    }

    
    void Update()
    {

        transform.position = new Vector3(Right_Hand_Controller.transform.position.x, Right_Hand_Controller.transform.position.y, Right_Hand_Controller.transform.position.z);
        transform.rotation = new Quaternion(Right_Hand_Controller.transform.rotation.x, Right_Hand_Controller.transform.rotation.y, Right_Hand_Controller.transform.roation.z, Right_Hand_Controller.transform.roation.w);
    }

}
