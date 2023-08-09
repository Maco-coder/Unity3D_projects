using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haptics_Tree : MonoBehaviour
{

    public GameObject cube_outter_apple ;


    void Start()
    {
        
    }

    void Update()
    {

    }


    void OnJointBreak(float breakForce)
    {

        cube_outter_apple.GetComponent<HapticEffect>().SetActive(true);
        Debug.Log("The apple has been plucked from the tree!, force: " + breakForce);

    }


}
