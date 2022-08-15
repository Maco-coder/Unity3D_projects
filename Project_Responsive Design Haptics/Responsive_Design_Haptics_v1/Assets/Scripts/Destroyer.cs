//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    public GameObject Joint_Object1;


    void Start()
    {
        Joint_Object1.SetActive (false)  ;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Test_Apple")
        {
            Debug.Log("collision detected");
            Joint_Object1.SetActive (true)  ;
            //Destroy(collision.gameObject) ;
        }
    }

}
