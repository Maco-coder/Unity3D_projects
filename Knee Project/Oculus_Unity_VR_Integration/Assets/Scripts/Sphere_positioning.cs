using UnityEngine;

public class SoftBodyFixedPosition : MonoBehaviour
{
    private Vector3 fixedPosition;
    private Quaternion fixedRotation;

    void Start()
    {
        // Save the initial position and rotation
        fixedPosition = transform.position;
        fixedRotation = transform.rotation;
    }

    void LateUpdate()
    {
        // After physics has updated, reset the position and rotation
        transform.position = fixedPosition;
        transform.rotation = fixedRotation;
    }
}