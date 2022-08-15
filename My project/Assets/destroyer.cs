//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour
{
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
        {
            Destroy(collision.gameObject);
        }
    }
    
}
