using UnityEngine;
using System.Collections;

public class WaveHandler : MonoBehaviour {

    [System.Serializable]
    private class WaveObject
    {
        public float EntryScore;
        public float SpawnRate;
        public GameObject[] NPC;
    }

    [SerializeField]
    private WaveObject[] m_wave;

    private int m_waveIndex = 0;
    private int m_waveMax;

    private GameObject m_object;

    public void Reset()
    {
        m_waveIndex = 0;
        StopAllCoroutines();
        Destroy(m_object);
        m_object = new GameObject();
    }

    public int Wave { get { return m_waveIndex; } }

    public void Begin()
    {
        StartCoroutine(SpawnLoop());
    }

    private Vector3 SpawnPosition()
    {
        bool left = (int)(Random.value * 100) % 2 == 1;
        float range = Random.value * 40;
        float radius = (range + 10) * Mathf.Tan(Mathf.Deg2Rad * Camera.main.fieldOfView / 1.29f) + 3.0f;
        radius = left ? radius : -radius;

        return new Vector3(radius,0,range);
    }

    private IEnumerator SpawnLoop()
    {
        GameObject g = m_wave[m_waveIndex].NPC[(int)(m_wave[m_waveIndex].NPC.Length * Random.Range(0, 0.99f))];
        g = GameObject.Instantiate(g);
        g.transform.position = SpawnPosition();

        g.transform.SetParent(m_object.transform);
        g.transform.LookAt(new Vector3(0,0,g.transform.position.z));
        yield return new WaitForSeconds(m_wave[m_waveIndex].SpawnRate);
        StartCoroutine(SpawnLoop());
    }

    private void ProgressWave()
    {
        int next = m_waveIndex + 1;
        next = Mathf.Min(next, m_waveMax);

        m_waveIndex = m_wave[next].EntryScore <= ScoreHandler.Total() ? next : m_waveIndex;
    }
    
	void Start () {
        m_waveMax = m_wave.Length - 1;
        Reset();
	}

    
	
	void Update () {
        ProgressWave();
	}
}
