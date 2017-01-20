using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIHandler : MonoBehaviour {

    [System.Serializable]
    private class TextArray
    {
        public Text[] text;
    }

    [SerializeField, Range(1.0f, 5.0f)]
    private float m_fadeRate = 2.0f;
    [SerializeField]
    private TextArray[] m_text;

    private bool m_fade = false;
    
	void Start () {
        foreach(TextArray a in m_text)
        {
            foreach(Text t in a.text)
            {
                Color c = t.color;
                c.a = 0.0f;
                t.color = c;
            }
        }
	}

    void Update()
    {
        if(Input.anyKeyDown)
        {
            Fade();
        }
    }

    public void Fade(uint collection = 0, bool fadeIn = true)
    {
        m_fade = true;
        StartCoroutine(FadeLoop(collection, fadeIn));
        StartCoroutine(FadeCancel());
    }

    private IEnumerator FadeLoop(uint collection, bool fadeIn)
    {
        yield return new WaitWhile(() => {
            foreach (Text t in m_text[collection].text)
            {
                Color c = t.color;
                c.a += (fadeIn ? Time.deltaTime : -Time.deltaTime) / m_fadeRate;
                t.color = c;
            }
            return m_fade;
        });
    }

    private IEnumerator FadeCancel()
    {
        yield return new WaitForSeconds(m_fadeRate);
        m_fade = false;
    }

}
