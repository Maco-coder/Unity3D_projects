using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject bounding_area;
    private Vector3 origin_pos;
    
    void Start()
    {
        origin_pos = transform.position;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == bounding_area)
        {
            print("RESPAWNED " + gameObject.name);
            transform.position = origin_pos;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
