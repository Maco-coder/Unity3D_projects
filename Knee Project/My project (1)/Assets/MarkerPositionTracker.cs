using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaturalPoint;
using NaturalPoint.NatNetLib;


public class MarkerPositionTracker : MonoBehaviour
{
    public OptitrackStreamingClient StreamingClient;
    public Transform trackedObject;

    void Update()
    {
        // Fix for CS0176: Use the class name to call the static method FindDefaultClient  
        if (StreamingClient != null && OptitrackStreamingClient.FindDefaultClient() != null)
        {
            List<OptitrackMarkerState> unlabeledMarkers = StreamingClient.GetLatestMarkerStates();

            if (unlabeledMarkers != null && unlabeledMarkers.Count > 0)
            {
                Vector3 markerPosition = unlabeledMarkers[0].Position;

                if (trackedObject != null)
                {
                    trackedObject.position = markerPosition;
                }
                else
                {
                    Debug.Log("Marker Position: " + markerPosition);
                }
            }
            else
            {
                Debug.Log("No unlabeled markers detected.");
            }
        }
        else
        {
            Debug.Log("OptiTrack Streaming Client not connected.");
        }
    }
}
