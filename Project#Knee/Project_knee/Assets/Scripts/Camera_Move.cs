using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Move : MonoBehaviour
{

    public float speed    ;
    public float waitTime ;
    private float timer   ;

    void Start()
    {
        
    }


    void Update()
    {
        timer += Time.deltaTime ;
        
        if (timer >= waitTime)
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }
    }
}
