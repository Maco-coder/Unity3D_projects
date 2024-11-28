using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;

public class Quaternion_rotation_trackers : MonoBehaviour
{

    public Transform tracker1   ;
    public Transform tracker2   ;
    public Transform virtualKnee;

    void Start()
    {
        
    }

    void Update()
    {
        // Get the rotation of both trackers (in world space)
        Quaternion VIVErotation1 = tracker1.rotation;
        Quaternion VIVErotation2 = tracker2.rotation;

        // Calculate the relative rotation between the two trackers
        Quaternion relativeRotation = Quaternion.Inverse(VIVErotation1)*VIVErotation2 ;

        // Apply the relative rotation to the virtual knee
        virtualKnee.rotation = relativeRotation ;
    }
}
