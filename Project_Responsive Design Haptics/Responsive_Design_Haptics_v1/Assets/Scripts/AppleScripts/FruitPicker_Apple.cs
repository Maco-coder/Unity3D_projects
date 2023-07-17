using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPicker_Apple : MonoBehaviour
{
    public GameObject newJoint;

    void OnCollisionEnter(Collision targetObj)
    {
        if (targetObj.gameObject.tag == "Cube_Joint_Apple")
        {
            Destroy(targetObj.gameObject);
            newJoint.SetActive(true);

        }

    }

}
