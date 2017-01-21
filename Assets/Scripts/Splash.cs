using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {

    private ParticleSystem m_particles;

	// Use this for initialization
	void Start () {
        m_particles = GetComponent<ParticleSystem>();
        m_particles.Stop();
        Debug.Log("Start");
    }

    void OnTriggerEnter(Collider col)
    {
        m_particles.Play();
        Debug.Log("Enter");
    }

    void OnTriggerExit(Collider col)
    {
        m_particles.Stop();
        Debug.Log("Exit");
    }
}
