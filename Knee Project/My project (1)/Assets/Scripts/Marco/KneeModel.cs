using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;

public class KneeModel : MonoBehaviour
{
    public Transform hip_markerSet ;  // The three markers on the 3D printed part with clamps
    private Vector3 positionOffset = new Vector3(0.5121f, -0.03f, -0.753f);  // Offset required to align virtual manikin with hip_markerSet; did trial an error to find it
    private Quaternion rotationOffset = Quaternion.Euler(-90f, 0f, 150f)  ;  // Rotation required to align virtual manikin with hip_markerSet; did trial an error to find it

    public GameObject kneeModelPrefab;  // Prefab for the knee model (manikin)

    void Update()
    {
        if (hip_markerSet != null)
        {
            kneeModelPrefab.transform.position = hip_markerSet.position + positionOffset;
            kneeModelPrefab.transform.rotation = rotationOffset;
        }
    }
}