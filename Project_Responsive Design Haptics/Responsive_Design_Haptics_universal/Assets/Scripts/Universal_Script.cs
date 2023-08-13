
using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;
using UnityEngine.UI             ;
using UnityEngine.SceneManagement;


public class Universal_Script : MonoBehaviour
{

    public static int device = OpeningScene_Devices.chosen_device ;

    public GameObject Apple  ;
    public GameObject Picker ;
       

    void Start()
    {
        
    }

    void Update()
    {

        
        if (device == 1)
        {
            Debug.Log("The device chosen was VR controller") ;
            Apple.GetComponent<SpringJoint>().breakForce = 0 ;


        }


        if (device == 2)
        {
            Debug.Log("The device chosen was 3D Touch");
        }


        if (device == 3)
        {
            Debug.Log("The device chosen was Fruit picker");
        }
        
        
    }

}