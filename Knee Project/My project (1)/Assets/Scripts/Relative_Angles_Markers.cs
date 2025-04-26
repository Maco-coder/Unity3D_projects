using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;

public class Relative_Angles_Markers : MonoBehaviour
{
    public Transform backOfHandMarker;  // Marker 1: Back of the Hand (Reference)
    public Transform indexMarker;       // Marker 2: Index (or other part of hand)

    void Update()
    {
        // Step 1: Calculate the vector between the two markers (index to back of hand)
        Vector3 vectorBetweenMarkers = indexMarker.position - backOfHandMarker.position;

        // Step 2: Normalize the vector to get the direction
        Vector3 unitVectorBetweenMarkers = vectorBetweenMarkers.normalized;

        // Step 3: Calculate angles with respect to the reference axes (X, Y, Z)
        float angleWithX = Vector3.Angle(unitVectorBetweenMarkers, Vector3.right); // Angle relative to X-axis
        float angleWithY = Vector3.Angle(unitVectorBetweenMarkers, Vector3.up);    // Angle relative to Y-axis
        float angleWithZ = Vector3.Angle(unitVectorBetweenMarkers, Vector3.forward); // Angle relative to Z-axis

        // Optionally, use the angles for animation or control in Unity
        Debug.Log("Angle with X-axis: " + angleWithX);
        Debug.Log("Angle with Y-axis: " + angleWithY);
        Debug.Log("Angle with Z-axis: " + angleWithZ);

        // You can use the angle data to animate a 3D model, trigger actions, etc.
    }
}
