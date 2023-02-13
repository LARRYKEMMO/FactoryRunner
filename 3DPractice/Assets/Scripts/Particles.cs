using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{

    ParticleSystem groundParticles;
    private bool collided = false;
    void Start()
    {
        groundParticles = GetComponentInChildren<ParticleSystem>();
        groundParticles.Stop();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !collided)
        {
            collided = true;
            groundParticles.Play();
        }

    }
}
