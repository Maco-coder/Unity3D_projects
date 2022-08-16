//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    public GameObject Joint_Object1; // Red space with friction effect //
    public GameObject Joint_Object2; // Sphere that connects with apple //


    void Start()
    {
        Joint_Object1.SetActive (false) ;
        Joint_Object2.SetActive (false) ;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Test_Apple")
        {
            Debug.Log("collision detected") ;
            Joint_Object1.SetActive (true)  ;
            Joint_Object2.SetActive (true)  ;
            //Destroy(Cube_spring)  ;
        }
    }

}
