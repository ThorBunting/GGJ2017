using UnityEngine;
using System.Collections;

public class TentacleControls : MonoBehaviour
{
    [SerializeField]
    private GameObject tentacleTop;
    [SerializeField]
    private int m_player = 0;
    private float forceMultiplier = 200;


    private float maxSpeed = 200f;
    private string verticalAxis;
    private string horizontalAxis;

    Rigidbody r;


    public int Player { get { return m_player; } }

    void Start()
    {
        verticalAxis = "Vertical" + m_player.ToString();
        horizontalAxis = "Horizontal" + m_player.ToString();
        r = tentacleTop.GetComponent<Rigidbody>();
    }

    void Update()
    {
        float vert = Input.GetAxis(verticalAxis) * forceMultiplier;
        float hori = Input.GetAxis(horizontalAxis) * forceMultiplier;
		
        Vector3 force = new Vector3(hori, Mathf.Min(0.0f, vert), Mathf.Max(0.0f, -vert));

        Debug.Log(r.velocity.magnitude);

        if (r.velocity.magnitude < maxSpeed)
        {
            tentacleTop.GetComponent<Rigidbody>().AddForce(hori,  vert, Mathf.Max(0.0f, -vert), ForceMode.Force);
        }
    }
}