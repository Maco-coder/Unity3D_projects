//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Angles : MonoBehaviour
{

    public Transform element ;
    public Text x_text       ;
    //public Text y_text      ;
    //public Text z_text      ;

    void Start()
    {
        
    }

    void Update()
    {
        //Debug.Log(element.eulerAngles.x);
        x_text.text = element.eulerAngles.x.ToString("0");

    }
}
