using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreHandler : MonoBehaviour {

    private static string m_format = "D3";
    
    private static Text[] m_text = new Text[2];
    private static float[] m_score = new float[2] { 0.0f, 0.0f };

    public static string Format { get { return m_format; } }

    public static void Reset()
    {
        m_score = new float[2] { 0.0f, 0.0f };
        m_text[0].text = 0.ToString(m_format);
        m_text[1].text = 0.ToString(m_format);
    }

    public static void Add(float score, int player)
    {
        m_score[player] += score;
        m_text[player].text = ((int)m_score[player]).ToString(m_format);
    }

    public static float Get(int player)
    {
        return m_score[player];
    }

    public static int Higher()
    {
        return
            m_score[0] != m_score[1] ?
                m_score[0] > m_score[1] ?
                    0 :
                    1 :
                2;
    }

    void Start()
    {
        m_text[0] = transform.GetChild(0).GetComponent<Text>();
        m_text[1] = transform.GetChild(1).GetComponent<Text>();
        Reset();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Add(250.0f, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Add(500.0f, 1);
        }
    }
}
