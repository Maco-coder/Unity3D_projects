using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;

public class KneeModel : MonoBehaviour
{
    public Transform hip_markerSet ;  // The three markers on the 3D printed part with clamps
    private Vector3 positionOffset = new Vector3(0.05f, 0.0f, 0.04f) ;  // Offset required to align virtual manikin with hip_markerSet; did trial an error to find it

    public Transform upper_leg_cube;
    public Transform lower_leg_cube;

    public GameObject kneeModelPrefab   ;  // Prefab for the knee model (manikin)
    public GameObject kneeModelHipJoint ;
    public GameObject kneeModelKneeJoint;

    private float initialOffsetKnee_x;
    private float initialOffsetKnee_z;


    void Update()
    {

        if (upper_leg_cube != null && lower_leg_cube != null && kneeModelPrefab != null && hip_markerSet != null)
        {
            kneeModelPrefab.transform.position = hip_markerSet.position + positionOffset;

            Quaternion hipRotation = hip_markerSet.rotation ;
            Vector3 hipEulerAngles = hipRotation.eulerAngles;
            hipEulerAngles.x = NormalizeAngles(hipEulerAngles.x);
            hipEulerAngles.y = NormalizeAngles(hipEulerAngles.y);
            hipEulerAngles.z = NormalizeAngles(hipEulerAngles.z);

            Vector3 prefabEulerAngles = kneeModelPrefab.transform.rotation.eulerAngles;
            prefabEulerAngles.x = -90f;
            prefabEulerAngles.y = 0f  ;
            prefabEulerAngles.z = NormalizeAngles(hipEulerAngles.y + 180.0f);

            kneeModelPrefab.transform.localEulerAngles = prefabEulerAngles;


            Quaternion upperLegRotation = upper_leg_cube.rotation;
            Vector3 upperLegEulerAngles = upperLegRotation.eulerAngles;
            upperLegEulerAngles.x = NormalizeAngles(upperLegEulerAngles.x) ;
            upperLegEulerAngles.y = NormalizeAngles(upperLegEulerAngles.y) ;
            upperLegEulerAngles.z = NormalizeAngles(upperLegEulerAngles.z) ;

            Quaternion lowerLegRotation = lower_leg_cube.rotation;
            Vector3 lowerLegEulerAngles = lowerLegRotation.eulerAngles;
            lowerLegEulerAngles.x = NormalizeAngles(lowerLegEulerAngles.x) ;
            lowerLegEulerAngles.y = NormalizeAngles(lowerLegEulerAngles.y) ;
            lowerLegEulerAngles.z = NormalizeAngles(lowerLegEulerAngles.z) ;

            Quaternion relativeRotation = Quaternion.Inverse(lowerLegRotation) * upperLegRotation;  // Relative rotation of the lower leg with respect to the upper leg
            Vector3 relativeEulerAngles = relativeRotation.eulerAngles;
            relativeEulerAngles.x = NormalizeAngles(relativeEulerAngles.x) ;
            relativeEulerAngles.y = NormalizeAngles(relativeEulerAngles.y) ;
            relativeEulerAngles.z = NormalizeAngles(relativeEulerAngles.z) ;

            Quaternion HipThighrelativeRotation = Quaternion.Inverse(upperLegRotation) * hip_markerSet.rotation;  // Relative rotation of the upper leg with respect to hip
            Vector3 HipThighrelativeEulerAngles = HipThighrelativeRotation.eulerAngles;
            HipThighrelativeEulerAngles.x = NormalizeAngles(HipThighrelativeEulerAngles.x);
            HipThighrelativeEulerAngles.y = NormalizeAngles(HipThighrelativeEulerAngles.y);
            HipThighrelativeEulerAngles.z = NormalizeAngles(HipThighrelativeEulerAngles.z);

            //Debug.Log("Relative Euler Angles: " + relativeEulerAngles);


            Vector3 currentHipRotation = kneeModelHipJoint.transform.localEulerAngles;
            currentHipRotation.x = HipThighrelativeEulerAngles.x;
            currentHipRotation.z = - HipThighrelativeEulerAngles.y + 181.0f;
            kneeModelHipJoint.transform.localEulerAngles = currentHipRotation;

            Debug.Log("Relative Euler Angles: " + HipThighrelativeEulerAngles.y);

            Vector3 currentKneeRotation = kneeModelKneeJoint.transform.localEulerAngles;
            currentKneeRotation.x = -relativeEulerAngles.x ;
            currentKneeRotation.z = -relativeEulerAngles.y ;
            kneeModelKneeJoint.transform.localEulerAngles = currentKneeRotation;

        }

    }

    float NormalizeAngles(float angle)
    {
        if (angle > 180f)
            angle -= 360f;
        else if (angle < -180f)
            angle += 360f;

        return angle;
    }

}