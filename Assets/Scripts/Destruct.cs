using UnityEngine;
using System.Collections;

public class Destruct : MonoBehaviour
{

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Tentacle")
        {
            Rigidbody[] rbs = gameObject.GetComponentsInChildren<Rigidbody>();
            GetComponent<Collider>().enabled = false;
            foreach (Rigidbody rb in rbs)
            {
                rb.AddExplosionForce(200f, transform.position, 5f);
            }
        }
    }
}
