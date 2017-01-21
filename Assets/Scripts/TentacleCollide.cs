using UnityEngine;
using System.Collections;

public class TentacleCollide : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Destructible")
        {
            Rigidbody[] rbs = col.gameObject.GetComponentsInChildren<Rigidbody>();
            FloatingObject[] fos = col.gameObject.GetComponentsInChildren<FloatingObject>();
            foreach(Rigidbody rb in rbs)
            {
                rb.useGravity = true;
                rb.AddExplosionForce(10f, rb.transform.position, 5f);
            }
            foreach(FloatingObject fo in fos)
            {
                fo.enabled = true;
            }
        }
    }
}
