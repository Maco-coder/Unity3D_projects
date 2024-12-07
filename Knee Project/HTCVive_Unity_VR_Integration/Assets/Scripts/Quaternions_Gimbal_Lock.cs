using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerRotation : MonoBehaviour
{
    public Transform viveTracker; // Reference to the VIVE tracker in the scene
    private Quaternion initialTrackerRotation;

    void Start()
    {
        // Capture the initial rotation of the VIVE tracker
        initialTrackerRotation = viveTracker.rotation;
    }

    void Update()
    {
        // Calculate the relative rotation of the tracker compared to its initial rotation
        Quaternion relativeRotation = Quaternion.Inverse(initialTrackerRotation) * viveTracker.rotation;

        // Apply this relative rotation to the object
        transform.rotation = relativeRotation;
    }
}
