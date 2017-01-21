using UnityEngine;
using System.Collections;

public class KillPlane : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        Destroy(col.gameObject);
    }
}
