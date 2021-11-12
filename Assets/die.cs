using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
    public float health;
    public float Vel;
    public int gibCount;
    public float spreadAngle;
    public GameObject chunk;
    public Transform chunkExit;

    List<Quaternion> gibs;

    public AudioSource audioSource;

    public AudioSource audioSource2;

    void Start()
    {
        gibs = new List<Quaternion>(gibCount);

        for (int i = 0; i < gibCount; i++)
        {
            gibs.Add(Quaternion.Euler(Vector3.zero));
        }
    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider Collision)
    {
        if (Collision.gameObject.tag == "player")
        {
            audioSource2.Play();
        }

        if (Collision.gameObject.tag == "bullet")
        {
            audioSource.Play();

            health--;

            Debug.Log(health);

            if (health < 0)
            {
                health = 0;

                for (int i = 0; i < gibCount; i++)
                {
                    audioSource.Play();

                    Destroy(gameObject);

                    gibs[i] = Random.rotation;
                    GameObject gib = Instantiate(chunk, chunkExit.position, chunkExit.transform.rotation);
                    gib.transform.rotation = Quaternion.RotateTowards(gib.transform.rotation, gibs[i], spreadAngle);
                    gib.GetComponent<Rigidbody>().AddForce(gib.transform.forward * Vel);

                    i++;
                }
            }
        }
    }
}
