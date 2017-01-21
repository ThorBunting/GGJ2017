using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {

    private ParticleSystem m_particles;

	// Use this for initialization
	void Start () {
        m_particles = GetComponent<ParticleSystem>();
        m_particles.Stop();
    }

    void OnTriggerEnter(Collider col)
    {
        m_particles.Play();
    }

    void OnTriggerExit(Collider col)
    {
        m_particles.Stop();
    }
}
