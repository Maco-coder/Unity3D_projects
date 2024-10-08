using UnityEngine;

public class DeformCube : MonoBehaviour
{
    private Mesh mesh;
    private Vector3[] originalVertices;
    private Vector3[] deformedVertices;
    private float returnSpeed = 2.0f; // Speed at which the object returns to its original shape

    void Start()
    {
        // Get the mesh component
        mesh = GetComponent<MeshFilter>().mesh;
        // Store original vertices
        originalVertices = mesh.vertices;
        // Create a copy for deformation
        deformedVertices = new Vector3[originalVertices.Length];
        originalVertices.CopyTo(deformedVertices, 0);
    }

    void Update()
    {
        // Interpolate back to original shape over time
        for (int i = 0; i < deformedVertices.Length; i++)
        {
            deformedVertices[i] = Vector3.Lerp(deformedVertices[i], originalVertices[i], Time.deltaTime * returnSpeed);
        }

        // Apply the deformed vertices to the mesh
        mesh.vertices = deformedVertices;
        mesh.RecalculateNormals(); // Recalculate normals after deformation
        mesh.RecalculateBounds(); // Update bounds
    }

    void OnCollisionEnter(Collision collision)
    {
        // Get the point of impact
        Vector3 point = collision.contacts[0].point;
        // Deform the mesh at the impact point
        DeformAtPoint(point);
    }

    void DeformAtPoint(Vector3 point)
    {
        // Iterate through the mesh vertices
        for (int i = 0; i < originalVertices.Length; i++)
        {
            // Calculate the distance from the impact point
            float distance = Vector3.Distance(transform.TransformPoint(originalVertices[i]), point);
            if (distance < 1.0f) // Define the deformation radius
            {
                float deformationAmount = 1.0f - (distance / 1.0f); // Calculate the deformation factor
                deformedVertices[i] = originalVertices[i] + Vector3.up * deformationAmount; // Deform upwards
            }
            else
            {
                deformedVertices[i] = originalVertices[i]; // Keep original if outside radius
            }
        }
    }
}
