
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

/**
 * A simple copy of example code from the manual, modified to orient particles
 * based on the center of the system.
 */

[ExecuteInEditMode]
public class OrientParticles : MonoBehaviour
{

    ParticleSystem m_System;
    ParticleSystem.Particle[] m_Particles;
    public float angleOffset = 0.0f;

    private void Update()
    {
        InitializeIfNeeded();

        // GetParticles is allocation free because we reuse the m_Particles buffer between updates
        int numParticlesAlive = m_System.GetParticles(m_Particles);

        // Change only the particles that are alive
        for (int i = 0; i < numParticlesAlive; i++)
        {
            // use atan2 to calc angle based on position, then convert to degrees.
            float angle = Mathf.Atan2(m_Particles[i].position.x, m_Particles[i].position.z) * Mathf.Rad2Deg;
            // add the offset (in case the artwork is rotated, etc.)
            m_Particles[i].rotation = angle + angleOffset;
        }

        // Apply the particle changes to the particle system
        m_System.SetParticles(m_Particles, numParticlesAlive);
    }

    void InitializeIfNeeded()
    {
        if (m_System == null)
            m_System = GetComponent<ParticleSystem>();

        if (m_Particles == null || m_Particles.Length < m_System.maxParticles)
            m_Particles = new ParticleSystem.Particle[m_System.maxParticles]; 
    }

}