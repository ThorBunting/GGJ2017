using UnityEngine;
using System.Collections;

public class TentacleCollide : MonoBehaviour
{
	void Start()
    {
	
	}
	
	void Update()
    {
	
	}

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Collided");
        Debug.Log(col.tag);
        Debug.Log(col.name);
        if(col.tag == "Destructible")
        {
            Debug.Log("Boom!");
            Rigidbody[] rbs = col.gameObject.GetComponentsInChildren<Rigidbody>();
            foreach(Rigidbody rb in rbs)
            {
                rb.AddExplosionForce(10f, rb.transform.position, 5f);
            }
        }
    }
}
