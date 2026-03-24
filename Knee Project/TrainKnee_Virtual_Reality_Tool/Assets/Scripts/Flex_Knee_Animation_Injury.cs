
using UnityEngine;

public class Flex_Knee_Animation_Injury : MonoBehaviour
{
    public Transform childObject;   // Assign your child in the Inspector
    public float rotationSpeed = 100f; // Degrees per second
    public float minZ = -90f;       // Minimum rotation (degrees)
    public float maxZ = 90f;        // Maximum rotation (degrees)

    private float currentZ;

    void Start()
    {
        // Initialize current Z rotation
        currentZ = childObject.localEulerAngles.z;

        // Convert from 0–360 to -180–180 range
        if (currentZ > 180f)
            currentZ -= 360f;
    }

    void Update()
    {
        float input = 0f;

        // Get input from arrow keys
        if (Input.GetKey(KeyCode.LeftArrow))
            input = 1f;
        if (Input.GetKey(KeyCode.RightArrow))
            input = -1f;

        // Update rotation
        currentZ += input * rotationSpeed * Time.deltaTime;

        // Clamp rotation
        currentZ = Mathf.Clamp(currentZ, minZ, maxZ);

        // Apply rotation (only Z axis)
        childObject.localRotation = Quaternion.Euler(0f, 0f, currentZ);
    }
}