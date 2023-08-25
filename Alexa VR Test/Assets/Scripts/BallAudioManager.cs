using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAudioManager : MonoBehaviour
{
    public AudioClip paddle_sound;
    public AudioClip table_sound;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "paddle")
        {
            AudioSource.PlayClipAtPoint(paddle_sound, transform.position, Mathf.Clamp(other.impulse.magnitude / (10 * rb.mass), 0.1f, 1.0f));
        }
        else if (other.gameObject.tag == "table")
        {
            AudioSource.PlayClipAtPoint(table_sound, transform.position, Mathf.Clamp(other.impulse.magnitude/(10*rb.mass), 0.1f, 1.0f));
        }
    }
}
