using UnityEngine;
using System.Collections;

public class FloatingObject : MonoBehaviour
{

    private float waterLevel = 0f;
    private float floatHeight;
    private Vector3 buoyancyCentreOffset = new Vector3(0f, 0f, 0f);
    private float bounceDamp = 0.7f;
    private Rigidbody r;

    void Start()
    {
        floatHeight = Random.Range(0.05f, 0.25f);
        r = GetComponent<Rigidbody>();
    }

	void FixedUpdate()
    {
        Vector3 actionPoint = transform.position + transform.TransformDirection(buoyancyCentreOffset);
        float forceFactor = 1f - ((actionPoint.y - waterLevel) / floatHeight);

        if (forceFactor > 0f)
        {
            Vector3 uplift = -Physics.gravity * (forceFactor - r.velocity.y * bounceDamp);
            r.AddForceAtPosition(uplift, actionPoint);
        }
    }
}
