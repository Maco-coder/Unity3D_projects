using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAudioManager : MonoBehaviour
{
    public AudioClip paddle_sound;
    public AudioClip table_sound;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "paddle")
        {
            AudioSource.PlayClipAtPoint(paddle_sound, transform.position);
        }
        else if (other.gameObject.tag == "table")
        {
            AudioSource.PlayClipAtPoint(table_sound, transform.position);
        }
    }
}
