using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{
    
    public GameObject tree;
    public GameObject apple;
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        Distance_ = Vector3.Distance(tree.transform.position,apple.transform.position);

        if (Distance_ < 3)
        {

        }

    }
}
