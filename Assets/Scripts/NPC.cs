using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

    [SerializeField]
    private float m_health = 10.0f;

    [SerializeField]
    private float m_speed = 5.0f;

    [SerializeField]
    private float m_points = 50.0f;

    public float Points { get { return m_points; } }
    public float Health { get { return m_health; } set { m_health = value; } }
	
	void FixedUpdate () {
        transform.position += m_speed * transform.forward * Time.fixedDeltaTime;
	}
}
