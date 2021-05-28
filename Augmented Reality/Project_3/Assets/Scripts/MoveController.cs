using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{

    public ParticleSystem flame1PS;
    public ParticleSystem flame2PS;

    public ParticleSystem rings1PS;
    public ParticleSystem rings2PS;
    public ParticleSystem rings3PS;
    public ParticleSystem rings4PS;
    public ParticleSystem rings5PS;
    public ParticleSystem rings6PS;

    public void Playflame1()
    {
        flame1PS.Play();
    }

    public void Playflame2()
    {
        flame2PS.Play();
    }

    public void PlayRing()
    {
        rings1PS.Play();
        rings2PS.Play();
        rings3PS.Play();
        rings4PS.Play();
        rings5PS.Play();
        rings6PS.Play();
    }


}
