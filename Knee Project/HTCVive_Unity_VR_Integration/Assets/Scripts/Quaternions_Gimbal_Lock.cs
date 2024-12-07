using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quaternions_Gimbal_Lock : MonoBehaviour
{
    public Transform tracker;  // Assign the VIVE tracker Transform
    public Transform targetObject;  // The object to rotate

    private Quaternion initialTrackerRotation;  // Tracker's starting orientation
    private Quaternion objectInitialRotation;  // Object's starting orientation
    private Quaternion offsetRotation;  // Offset to align the tracker and object

    private bool initialized = false;  // Flag to ensure initialization happens once

    void Start()
    {
        // Store the initial rotations
        initialTrackerRotation = tracker.rotation;
        objectInitialRotation = targetObject.rotation;

        // Compute the offset to align tracker's initial rotation with the object's initial rotation
        offsetRotation = Quaternion.Inverse(initialTrackerRotation) * objectInitialRotation;
    }

    void Update()
    {
        // Compute the relative rotation of the tracker
        Quaternion currentTrackerRotation = tracker.rotation;
        Quaternion relativeRotation = currentTrackerRotation * Quaternion.Inverse(initialTrackerRotation);

        // Apply the relative rotation to the object, preserving the offset
        targetObject.rotation = relativeRotation * offsetRotation;
    }
}