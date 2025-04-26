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
        if (StreamingClient != null && StreamingClient.IsConnected)
        {
            UnlabeledMarker[] unlabeledMarkers = StreamingClient.GetUnlabeledMarkers();

            if (unlabeledMarkers.Length > 0)
            {
                // Get the position of the first unlabeled marker
                Vector3 markerPosition = unlabeledMarkers[0].Position;

                // OptiTrack coordinates are often in meters, Unity in world units
                // You might need to adjust the scale and coordinate system
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
