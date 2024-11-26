using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;

public class Rotation_NewBehaviourScript : MonoBehaviour
{

    public GameObject viveTracker1;
    public GameObject knee        ;

    public int offset_x_tracker1;
    public int offset_y_tracker1;
    public int offset_z_tracker1;

    void Start()
    {
        
    }

    void Update()
    {
        if (viveTracker1 != null)
        {
            transform.rotation = viveTracker1.transform.rotation;
        }   
    }
}