using UnityEngine;
using System.Collections;

public class TentacleControls : MonoBehaviour
{
    [SerializeField]
    private GameObject tentacleTop;
    [SerializeField]
    private int m_player = 0;
    private float forceMultiplier = 200;

    [SerializeField]
    private Material[] m_material;
    private int m_materialID;

    private float maxSpeed = 200f;

    private string verticalAxis;
    private string horizontalAxis;
    private KeyCode colourButton;

    Rigidbody rig;
    Renderer ren;

    public int Player { get { return m_player; } }

    void Start()
    {
        m_materialID = m_player;
        verticalAxis = "Vertical" + m_player.ToString();
        horizontalAxis = "Horizontal" + m_player.ToString();
        colourButton = KeyCode.JoystickButton4 + m_player;
        rig = tentacleTop.GetComponent<Rigidbody>();
        ren = transform.GetChild(1).GetComponent<Renderer>();
    }

    void Update()
    {
        if (rig.velocity.magnitude < maxSpeed)
        {
            float vert = Input.GetAxis(verticalAxis) * forceMultiplier;
            float hori = Input.GetAxis(horizontalAxis) * forceMultiplier;
		
            Vector3 force = new Vector3(hori, Mathf.Max(0.0f, vert), -Mathf.Min(0.0f, vert) * 1.5f);
            tentacleTop.GetComponent<Rigidbody>().AddForce(force, ForceMode.Force);
        }

        if(Input.GetKeyDown(colourButton))
        {
            m_materialID = ++m_materialID % m_material.Length;
            Material m = ren.material;
            m = m_material[m_materialID];
            ren.material = m;
        }
    }
}