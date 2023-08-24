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

    void Start()
    {
        origin_pos = transform.position;
        origin_rot = transform.rotation;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == bounding_area)
        {
            print("RESPAWNED " + gameObject.name);
            AudioSource.PlayClipAtPoint(respawn_sound, origin_pos);
            transform.position = origin_pos;
            transform.rotation = origin_rot;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
