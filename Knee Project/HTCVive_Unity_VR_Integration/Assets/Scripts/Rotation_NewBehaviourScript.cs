using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;

public class Rotation_NewBehaviourScript : MonoBehaviour
{

    public GameObject viveTracker;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (viveTracker != null)
        {
            transform.rotation = viveTracker.transform.rotation;
        }   
    }
}
