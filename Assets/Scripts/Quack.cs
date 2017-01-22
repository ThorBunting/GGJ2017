using UnityEngine;
using System.Collections;

public class Quack : MonoBehaviour
{
    public AudioClip quack;
    public AudioSource quackSource;

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Tentacle")
        {
            quackSource.PlayOneShot(quack);
        }
    }

}
