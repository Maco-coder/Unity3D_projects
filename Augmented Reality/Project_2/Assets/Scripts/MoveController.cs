using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{

    public ParticleSystem flame1PS;
    public ParticleSystem flame2PS;


    public void PlayFlame1()
    {
        flame1PS.Play();
    }

    public void PlayFlame2()
    {
        flame2PS.Play();
    }

}
