using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die2 : MonoBehaviour
{
    public float health;
    public float Vel;
    public int gibCount;
    public float spreadAngle;
    public GameObject chunk;
    public Transform chunkExit;

    List<Quaternion> gibs;

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
        if (Collision.gameObject.tag == "ground")
        {
            health--;

            Debug.Log(health);

            if (health <= 0)
            {
                health = 0;

                for (int i = 0; i < gibCount; i++)
                {
                    Destroy(gameObject);

                    gibs[i] = Random.rotation;
                    GameObject gib = Instantiate(chunk, chunkExit.position, chunkExit.transform.rotation);
                    gib.transform.rotation = Quaternion.RotateTowards(gib.transform.rotation, gibs[i], spreadAngle);
                    gib.GetComponent<Rigidbody>().AddForce(gib.transform.forward * Vel);

                    i++;
                }
            }
        }

        if (Collision.gameObject.tag == "enemy")
        {
            health--;

            Debug.Log(health);

            if (health <= 0)
            {
                health = 0;

                for (int i = 0; i < gibCount; i++)
                {
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

    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "ground")
        {
            health--;

            Debug.Log(health);

            if (health <= 0)
            {
                health = 0;

                for (int i = 0; i < gibCount; i++)
                {
                    Destroy(gameObject);

                    gibs[i] = Random.rotation;
                    GameObject gib = Instantiate(chunk, chunkExit.position, chunkExit.transform.rotation);
                    gib.transform.rotation = Quaternion.RotateTowards(gib.transform.rotation, gibs[i], spreadAngle);
                    gib.GetComponent<Rigidbody>().AddForce(gib.transform.forward * Vel);

                    i++;
                }
            }
        }

        if (Collision.gameObject.tag == "enemy")
        {
            health--;

            Debug.Log(health);

            if (health <= 0)
            {
                health = 0;

                for (int i = 0; i < gibCount; i++)
                {
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
