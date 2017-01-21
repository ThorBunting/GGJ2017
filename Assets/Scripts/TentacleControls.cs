using UnityEngine;
using System.Collections;

public class TentacleControls : MonoBehaviour
{
    [SerializeField]
    private GameObject tentacleTop;
    private float forceMultiplier = 20;

    void Update()
    {
        float vert = Input.GetAxis("Vertical") * forceMultiplier;
        float hori = Input.GetAxis("Horizontal") * forceMultiplier;

        //if (hori >= 0)

            //Debug.Log("Force Added: " + new Vector3(vert, 0f, hori));

        tentacleTop.GetComponent<Rigidbody>().AddForce(vert, 0f, hori, ForceMode.Force);
    }
}