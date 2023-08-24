using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject bounding_area;
    private Vector3 origin_pos;
    public AudioClip respawn_sound;
    
    void Start()
    {
        origin_pos = transform.position;
    }

    void Update()
    {
        transform.position += new Vector3(0.01f, 0.0f, 0.0f);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == bounding_area)
        {
            AudioSource.PlayClipAtPoint(respawn_sound, origin_pos);
            transform.position = origin_pos;
        }
    }
}
