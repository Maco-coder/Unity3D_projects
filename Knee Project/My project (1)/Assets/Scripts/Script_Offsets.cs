using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Offsets : MonoBehaviour
{

    public GameObject Hip_reference;
    public GameObject Manikin_body ;

    public Vector3 Manikin_offset  ;


    void Start()
    {
        
    }

    void Update()
    {

        Vector3 Hip_reference_position = Hip_reference.transform.position  ;
        Vector3 Manikin_position = Hip_reference_position + Manikin_offset ;

        if (Manikin_body != null)
        {
            Manikin_body.transform.position = Manikin_position;
        }
    }
}