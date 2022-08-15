//using System.Collections        ;
//using System.Collections.Generic;
using UnityEngine;

public class Colliders : MonoBehaviour
{

    //public GameObject Joint_Object1;
    //public float speed = 2.5f;


    //void Start()
    //{
        //Joint_Object1.SetActive(true);
    //}


    private void onCollisionEnter(Collision col)
    {
        Destroy(gameObject);
    }

}
