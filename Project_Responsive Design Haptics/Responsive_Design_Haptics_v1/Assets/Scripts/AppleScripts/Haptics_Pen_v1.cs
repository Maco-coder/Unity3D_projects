
// HAPTICS_PEN_V1 //

using System.Collections          ;
using System.Collections.Generic  ;
using UnityEngine                 ;


public class Haptics_Pen_v1 : MonoBehaviour
{

    public GameObject cube_outter_apple ;


    void Start()
    {
        cube_outter_apple.SetActive(false);
    }

    void Update()
    {
        //cube_outter_apple.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z) ;
    }


    void OnJointBreak(float breakForce)
    {

        cube_outter_apple.SetActive(true);
        Debug.Log("The apple has been plucked from the tree!, force: " + breakForce);

    }


}
