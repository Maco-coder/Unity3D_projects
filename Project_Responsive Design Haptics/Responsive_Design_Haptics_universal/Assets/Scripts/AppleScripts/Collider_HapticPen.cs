
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_HapticPen : MonoBehaviour
{

    public string feedback_choice ; // WHAT THE DEVELOPER SPECIFIES IN JSON: constant, viscous, spring, friction, vibrate //
    
    // CONSTANT effect parameters //
    public float constant_direction_x ;
    public float constant_direction_y ;
    public float constant_direction_z ;
    public float constant_magnitude   ;

    // VISCOUS effect parameters //
     float viscous_gain      ;
     float viscous_magnitude ;

    // SPRING effect parameters //
    public float spring_gain       ;
    public float spring_magnitude  ;

    // FRICTION effect parameters //
    public float friction_gain      ;
    public float friction_magnitude ;

    // VIBRATE effect parameters //
    public float vibrate_gain        ;
    public float vibrate_magnitude   ;
    public float vibrate_frequency   ;
    public float vibrate_direction_x ;
    public float vibrate_direction_y ;
    public float vibrate_direction_z ;


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}