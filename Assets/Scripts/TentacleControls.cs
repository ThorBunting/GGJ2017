﻿using UnityEngine;
using System.Collections;

public class TentacleControls : MonoBehaviour
{
    [SerializeField]
    private GameObject tentacleTop;

    [SerializeField]
    private int m_player = 0;

    private string verticalAxis;
    private string horizontalAxis;
    private float forceMultiplier = 100;

    public int Player { get { return m_player; } }

    void Start()
    {
        verticalAxis = "Vertical" + m_player.ToString();
        horizontalAxis = "Horizontal" + m_player.ToString();
    }

    void Update()
    {
        float vert = Input.GetAxis(verticalAxis) * forceMultiplier;
        float hori = Input.GetAxis(horizontalAxis) * forceMultiplier;

        tentacleTop.GetComponent<Rigidbody>().AddForce(hori, Mathf.Min(0.0f, vert), Mathf.Max(0.0f, -vert), ForceMode.Force);
    }
}