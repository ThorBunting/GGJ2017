using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    [SerializeField, Range(10.0f, 180.0f)]
    private float m_initialTime = 120.0f;

    [SerializeField]
    private Text m_clock;

    private bool m_active = false;
    private float m_time;

    public bool isActive { get { return m_active; } }

    public void Reset()
    {
        m_time = m_initialTime;
        m_clock.text = string.Format("{0}:{1:00}:{2:00}", (int)m_time / 60, (int)m_time % 60, (m_time - (int)m_time) * 99);
    }

    public void StartTimer()
    {
        Reset();
        m_active = true;
    }

    private void TimeLoop()
    {
        if (m_active)
        {
            m_time -= Time.deltaTime;
            if(m_time < 0.0f)
            {
                m_time = 0.0f;
                m_active = false;
            }
            m_clock.text = string.Format("{0}:{1:00}:{2:00}", (int)m_time / 60, (int)m_time % 60, (m_time - (int)m_time) * 99);
        }
    }

	void Update ()
    {
        TimeLoop();
	}
}
