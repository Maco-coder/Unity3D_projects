using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haptics_Pen_v2 : MonoBehaviour
{

    public GameObject feedback_capsule;

    
    void Start()
    {
        feedback_capsule.SetActive(false);
    }

    
    void Update()
    {
        
    }


    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "apple_TOUCH")
        {
            feedback_capsule.SetActive(true);
        }

    }



    }
