using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaturalPoint;
using NaturalPoint.NatNetLib;

public class SteamVRHand_Optitrack : MonoBehaviour
{
    /*
     * this script need external library from NaturalPoint, external setup in Motive
     * look for the marker IDs in Motive and assign them to the finger tips
     * 
     * probably don't need coordinate system transformation, but it is there for future use and testing
     * play with tracking lost timeout to see how it affects the hand model
     * 
     * somehow single marker tracking is not working if 'Draw Markers' is NOT ticked in client script.
     * make sure to tick that to get data streaming. you can untick it once it flows the data.
     * 
     * future improvements: fallback mechanism for when the marker is not found (currently using last knwon position)
     *                      later iteration could implement 'default' position of each finger (i.e. make weight 0)
     *                      
     *                      also wrist tracking doesnt have fallback mechanism yet.
     *                      (we better have robust tracking for wrist, so we can use it for other things)
     *                      
     */

    [Header("SteamVR hand model")]
    public Transform handModel;

    [Header("Finger Tip IK Targets")]
    public Transform thumbTipTarget;
    public Transform indexTipTarget;
    public Transform middleTipTarget;
    public Transform ringTipTarget;
    public Transform pinkyTipTarget;

    [Header("Optitrack Marker IDs")]
    public string thumbMarkerID = "ThumbTip";
    public string indexMarkerID = "IndexTip";
    public string middleMarkerID = "MiddleTip";
    public string ringMarkerID = "RingTip";
    public string pinkyMarkerID = "PinkyTip";

    [Header("Coordinate System Transformation")]
    public Vector3 optitrackPositionScale = Vector3.one * 0.001f;
    public Vector3 optitrackRotationEulerOffset = Vector3.zero;
    public bool invertZAxis = false;

    [Header("Fallback Settings")]
    public float trackingLosttimeout = 0.2f;

    private OptitrackStreamingClient _optitrackClient;
    private Transform[] _fingerTipTargets;
    private string[] _markerNames;

    private Vector3[] lastKnownTargetPositions;
    private bool[] isFingerTracked;
    private float[] lastTrackedTime;


    // Start is called before the first frame update
    void Start()
    {
        _optitrackClient = FindAnyObjectByType<OptitrackStreamingClient>();
        if( _optitrackClient == null)
        {
            Debug.LogError("Optitrack client not found");
            enabled = false;
            return;
        }

        if (handModel == null)
        {
            Debug.LogError("hand model not assigned");
            enabled = false;
            return;
        }

        _fingerTipTargets = new Transform[] {thumbTipTarget, indexTipTarget, middleTipTarget, ringTipTarget, pinkyTipTarget};
        _markerNames = new string[] {thumbMarkerID, indexMarkerID, middleMarkerID, ringMarkerID, pinkyMarkerID};

        lastKnownTargetPositions = new Vector3[_fingerTipTargets.Length];
        isFingerTracked = new bool[_fingerTipTargets.Length];
        lastTrackedTime = new float[_fingerTipTargets.Length];

        for (int i = 0; i < _fingerTipTargets.Length; i++)
        {
            if (_fingerTipTargets[i] == null || string.IsNullOrEmpty(_markerNames[i]))
            {
                Debug.LogError($"Finger tip target or marker name is not assigned {i}");
                enabled = false;
                return;
            }

            if (_fingerTipTargets[i] != null)
            {
                lastKnownTargetPositions[i] = _fingerTipTargets[i].position;
                isFingerTracked[i] = false;
                lastTrackedTime[i] = Time.time;
            }
            else
            {
                Debug.LogError($"Finger tip target not assigned {i}");
                enabled = false;
                return;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_optitrackClient != null && OptitrackStreamingClient.FindDefaultClient() != null && handModel != null)
        {
            for (int i = 0; i < _fingerTipTargets.Length; i++)
            {
                UpdateFingerTargetPosition(_markerNames[i], _fingerTipTargets[i]);
            }
        }
    }

    void UpdateFingerTargetPosition(string markerName, Transform targetTransform)
    {
        if (targetTransform != null)
        {
            Vector3? markerPositionOptiTrack = GetMarkerPosition(markerName);
            if(markerPositionOptiTrack.HasValue)
            {
                Vector3 transformedPosition = Vector3.Scale(markerPositionOptiTrack.Value, optitrackPositionScale);
                //Vector3 transformedPosition = markerPositionOptiTrack.Value;
                Quaternion rotationOffset = Quaternion.Euler(optitrackRotationEulerOffset);
                transformedPosition = rotationOffset * transformedPosition;
                if(invertZAxis)
                {
                    transformedPosition.z *= -1f;
                }

                targetTransform.position = transformedPosition;

                lastKnownTargetPositions[System.Array.IndexOf(_markerNames, markerName)] = transformedPosition;
                isFingerTracked[System.Array.IndexOf(_markerNames, markerName)] = true;
                lastTrackedTime[System.Array.IndexOf(_markerNames, markerName)] = Time.time;

            }
            else
            {
                // fallback mechanism for when the marker is not found
                // If the marker is not found, use the last known position
                isFingerTracked[System.Array.IndexOf(_markerNames, markerName)] = false;
                if(Time.time - lastTrackedTime[System.Array.IndexOf(_markerNames, markerName)] > trackingLosttimeout)
                {
                    targetTransform.position = lastKnownTargetPositions[System.Array.IndexOf(_markerNames, markerName)];
                }

                //Debug.Log($"Marker '{markerName}' not found");
            }
        }
    }

    Vector3? GetMarkerPosition(string markerID)
    {
        if(_optitrackClient != null)
        {
            List<OptitrackMarkerState> markerStates = _optitrackClient.GetLatestMarkerStates();
            //Debug.Log(markerStates.Count);
            foreach(var marker in _optitrackClient.GetLatestMarkerStates())
            {
                //Debug.Log($"getting marker {marker.Id}");
                if(marker.Id.ToString() == markerID)
                {
                    return marker.Position;
                }
            }
        }
        return null;
    }
}
