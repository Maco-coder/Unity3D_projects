using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relative_Angles_Markers : MonoBehaviour
{
    public Transform backOfHandMarker;  // Marker 1: Reference (e.g., back of the hand)
    public Transform indexMarker;       // Marker 2: Tip of finger or other moving part

    void Update()
    {
        if (backOfHandMarker == null || indexMarker == null)
            return;

        // Vector from back of hand to index
        Vector3 direction = indexMarker.position - backOfHandMarker.position;

        // Visualize the direction vector in the Scene view
        Debug.DrawLine(backOfHandMarker.position, indexMarker.position, Color.red);

        // ---- Signed Angles ----
        // 1. Yaw: left/right (in XZ plane), around Y axis
        float yaw = Vector3.SignedAngle(Vector3.right, new Vector3(direction.x, 0f, direction.z), Vector3.up);

        // 2. Pitch: up/down (in XY plane), around Z axis
        float pitch = Vector3.SignedAngle(Vector3.right, new Vector3(direction.x, direction.y, 0f), Vector3.forward);

        // 3. Roll: twist (in YZ plane), around X axis
        float roll = Vector3.SignedAngle(Vector3.forward, new Vector3(0f, direction.y, direction.z), Vector3.right);

        // ---- Output ----
        Debug.Log($"Yaw (XZ): {yaw:F2}°, Pitch (XY): {pitch:F2}°, Roll (YZ): {roll:F2}°");
    }
}
