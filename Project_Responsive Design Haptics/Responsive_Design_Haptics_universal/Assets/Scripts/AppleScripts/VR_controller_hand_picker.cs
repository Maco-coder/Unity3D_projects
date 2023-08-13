
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_controller_hand_picker : MonoBehaviour
{

    public GameObject Right_Hand_Controller;
    public Vector3 new_pivot_picker       ;

    
    void Start()
    {
        
    }

    
    void Update()
    {

        Vector3 offset = transform.position - new_pivot_picker;
        foreach (Transform child in transform)
            child.transform.position += offset;
        transform.position = new_pivot_picker ;

        transform.position = new Vector3(Right_Hand_Controller.transform.position.x, Right_Hand_Controller.transform.position.y+0.6f, Right_Hand_Controller.transform.position.z);
        transform.rotation = new Quaternion(Right_Hand_Controller.transform.rotation.x, Right_Hand_Controller.transform.rotation.y, Right_Hand_Controller.transform.rotation.z, Right_Hand_Controller.transform.rotation.w);
    
    }
}
