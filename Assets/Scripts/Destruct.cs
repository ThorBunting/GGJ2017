using UnityEngine;
using System.Collections;

public class Destruct : MonoBehaviour
{
    [SerializeField]
    private float forceMultiplier = 20f;
    [SerializeField]
    private float radius = 5f;

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Tentacle")
        {
            bool br = false;
            int p = col.transform.root.GetComponent<TentacleControls>().Player;
            NPC n = GetComponent<NPC>();
            if(n != null)
            {
                ScoreHandler.Add(n.Points, p);
                n.Health -= col.relativeVelocity.magnitude / 10;
                br = n.Health < 0.0f;
            }else
            {
                br = true;
            }
			
            if(br)
            {
                GetComponent<BoxCollider>().enabled = false;

                Rigidbody[] rbs = gameObject.GetComponentsInChildren<Rigidbody>();
                Collider[] cols = GetComponents<Collider>();
                FloatingObject[] fos = gameObject.GetComponentsInChildren<FloatingObject>();
				AudioSource[] audioSources = gameObject.GetComponents<AudioSource>();
                ParticleSystem[] particles = gameObject.GetComponentsInChildren<ParticleSystem>();
     
				foreach(AudioSource audio in audioSources)
				{
					audio.Stop();
				}

                foreach(ParticleSystem particle in particles)
                {
                    particle.Play();
                }

                foreach(Collider c in cols)
                {
                    c.enabled = false;
                }

                foreach (Rigidbody rb in rbs)
                {
                    rb.useGravity = true;
                    rb.AddExplosionForce(forceMultiplier * col.relativeVelocity.magnitude, col.transform.position, radius);
                    rb.AddTorque(new Vector3(Random.Range(1f, 100f), Random.Range(1f, 100f), Random.Range(1f, 100f)));
                }

                foreach(FloatingObject fo in fos)
                {
                    fo.enabled = true;
                }
            }
        }
    }
}
