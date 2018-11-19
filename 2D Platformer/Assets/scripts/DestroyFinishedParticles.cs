using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFinishedParticles : MonoBehaviour
{

    private ParticleSystem thisParticlesystem;

    //Use this for initialization
    void Start()
    {
        thisParticlesystem = GetComponent<ParticleSystem>();
    }

    //Update is called once per frame
    void Update()
    {
        if (thisParticlesystem.isPlaying)
            return;
        Destroy(gameObject);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);

    }
}