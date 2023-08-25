using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject bounding_area;
    private Vector3 origin_pos;
    private Quaternion origin_rot;
    public AudioClip respawn_sound;
    private Rigidbody body;

    void Start()
    {
        origin_pos = transform.position;
        origin_rot = transform.rotation;
        body = GetComponent<Rigidbody>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == bounding_area)
        {
            print("RESPAWNED " + gameObject.name);
            AudioSource.PlayClipAtPoint(respawn_sound, origin_pos);
            transform.position = origin_pos;
            transform.rotation = origin_rot;
            body.angularVelocity = Vector3.zero;
            body.velocity = Vector3.zero;
        }
    }
}
