using UnityEngine;
using System.Collections;

public class GUIBlink : MonoBehaviour
{
    public Animator blinkAnim;

    void Start()
    {
        InvokeRepeating("Blink", 0f, 5f);
    }

    void Blink()
    {
        blinkAnim.SetTrigger("blink");
    }

}
