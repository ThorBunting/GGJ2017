using UnityEngine;
using System.Collections;

public class UIHandler : MonoBehaviour {
    [SerializeField, Range(1.0f, 5.0f)]
    private float m_fadeRate = 2.0f;
    [SerializeField]
    private CanvasGroup[] m_canvas;

    private bool[] m_fade;
    
	void Start () {
        foreach(CanvasGroup c in m_canvas)
        {
            c.alpha = 0.0f;
        }
        m_fade = new bool[m_canvas.Length];
	}

    public void Fade(uint collection = 0, bool fadeIn = true)
    {
        m_fade[collection] = true;
        StartCoroutine(FadeLoop(collection, fadeIn));
        StartCoroutine(FadeCancel(collection));
    }

    private IEnumerator FadeLoop(uint collection, bool fadeIn)
    {
        yield return new WaitWhile(() => {
            m_canvas[collection].alpha += (fadeIn ? Time.deltaTime : -Time.deltaTime) / m_fadeRate;
            return m_fade[collection];
        });
    }

    private IEnumerator FadeCancel(uint collection)
    {
        yield return new WaitForSeconds(m_fadeRate);
        m_fade[collection] = false;
    }

}
