using UnityEngine;
using System.Collections;

public class Destruct : MonoBehaviour
{
    [SerializeField]
    private float force = 100f;
    [SerializeField]
    private float radius = 5f;

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Tentacle")
        {
            int p = col.transform.root.GetComponent<TentacleControls>().Player;
            ScoreHandler.Add(GetComponent<NPC>().Points, p);
            GetComponent<BoxCollider>().enabled = false;

            Rigidbody[] rbs = gameObject.GetComponentsInChildren<Rigidbody>();
            GetComponent<Collider>().enabled = false;
            foreach (Rigidbody rb in rbs)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
    }
}
