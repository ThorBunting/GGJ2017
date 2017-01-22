using UnityEngine;
using System.Collections;

public class CamShake : MonoBehaviour {

    private Vector3 m_origin;

    void Start()
    {
        m_origin = transform.position;
    }

    void OnCollisionEnter(Collision col)
    {
        float f = col.relativeVelocity.magnitude;
        StartCoroutine(Shake(f));
    }

    private IEnumerator Shake(float force)
    {
        yield return new WaitWhile(() =>
        {
            transform.position = m_origin + new Vector3(Random.Range(-1.0f,1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized * force;
            force -= Time.deltaTime;
            force *= 0.9f;
            return force > 0.0f;
        });
    }
}
