using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;

public class Cube : MonoBehaviour
{
    
    public float speedX;
    public float speedY;
    public float speedZ;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(Vector3.right * speedX * Time.deltaTime)  ;
        transform.Rotate(Vector3.up * speedY * Time.deltaTime)     ;
        transform.Rotate(Vector3.forward * speedZ * Time.deltaTime);
    }
}
