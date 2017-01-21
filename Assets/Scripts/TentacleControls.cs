using UnityEngine;
using System.Collections;

public class TentacleControls : MonoBehaviour
{
    [SerializeField]
    private GameObject tentacleTop;

    [SerializeField]
    private int m_player = 0;

    private float forceMultiplier = 20;

    public int Player { get { return m_player; } }

    void Update()
    {
        float vert = Input.GetAxis("Vertical") * forceMultiplier;
        float hori = Input.GetAxis("Horizontal") * forceMultiplier;

        //if (hori >= 0)

            //Debug.Log("Force Added: " + new Vector3(vert, 0f, hori));

        tentacleTop.GetComponent<Rigidbody>().AddForce(vert, 0f, hori, ForceMode.Force);
    }
}