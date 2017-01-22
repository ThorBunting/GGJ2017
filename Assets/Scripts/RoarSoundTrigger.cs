using UnityEngine;
using System.Collections;

public class RoarSoundTrigger : MonoBehaviour {

    [SerializeField]
    private AudioSource soundSource;
    [SerializeField]
    private AudioClip roar;

	void Start()
    {
        InvokeRepeating("PlayRoar", 0, 90f);
    }

    private void PlayRoar()
    {
        soundSource.PlayOneShot(roar);
    }


}
