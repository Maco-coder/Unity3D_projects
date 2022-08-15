
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Object_Active : MonoBehaviour
{

    //public GameObject Joint_Object1;
    public float speed = 2.5f;


    void Start()
    {
        //Joint_Object1.SetActive(true);
    }


    void Update()
    {

        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time * speed, 5));
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    Joint_Object1.SetActive(true);
        //}

        //if (Input.GetKeyDown(KeyCode.Z))
        //{
            //Joint_Object1.SetActive(false);
        //}
    }


    void onCollisionEnter (Collision col)
    {
        if (col.gameObject.name == "Cube2")
        {
            Debug.Log("Collision Detected");
            Destroy(col.gameObject)        ;
        }
    }

}
