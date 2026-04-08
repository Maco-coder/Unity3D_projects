using System.Collections.Generic;
using UnityEngine;

public class MultiPropellerController : MonoBehaviour
{
    public List<Transform> propellers; // Assign all propeller transforms
    public float rotationSpeed = 360f;
    public Vector3 rotationAxis = Vector3.up;

    void Update()
    {
        foreach (Transform prop in propellers)
        {
            prop.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
        }
    }
}