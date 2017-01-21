using UnityEngine;
using System.Collections;

public class Destruct : MonoBehaviour
{
    [SerializeField]
    private float forceMultiplier = 20f;
    [SerializeField]
    private float radius = 5f;

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Tentacle")
        {
            int p = col.transform.root.GetComponent<TentacleControls>().Player;
            if(GetComponent<NPC>())
            {
                ScoreHandler.Add(GetComponent<NPC>().Points, p);
            }

            GetComponent<BoxCollider>().enabled = false;

            Rigidbody[] rbs = gameObject.GetComponentsInChildren<Rigidbody>();
            Collider[] cols = GetComponents<Collider>();

            foreach(Collider c in cols)
            {
                c.enabled = false;
            }

            FloatingObject[] fos = gameObject.GetComponentsInChildren<FloatingObject>();

            foreach (Rigidbody rb in rbs)
            {
                rb.useGravity = true;
                rb.AddExplosionForce(forceMultiplier * col.relativeVelocity.magnitude, col.transform.position, radius);
                rb.AddTorque(new Vector3(Random.Range(1f, 100f), Random.Range(1f, 100f), Random.Range(1f, 100f)));
            }

            foreach(FloatingObject fo in fos)
            {
                fo.enabled = true;
            }
        }
    }
}
