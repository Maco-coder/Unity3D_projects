//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
        {
            Debug.Log("collision detected");
            Destroy(collision.gameObject)  ;
        }
    }

}
