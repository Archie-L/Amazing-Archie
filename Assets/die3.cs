using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die3 : MonoBehaviour
{
    public float health;
    public ParticleSystem explosion;

    void Start()
    {

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

                explosion.Play(true);
                Destroy(gameObject);
            }
        }

        if (Collision.gameObject.tag == "enemy")
        {
            health--;

            Debug.Log(health);

            if (health <= 0)
            {
                health = 0;

                explosion.Play(true);
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "enemy")
        {
            health--;

            Debug.Log(health);

            if (health <= 0)
            {
                health = 0;

                explosion.Play(true);
                Destroy(gameObject);
            }
        }

        if(Collision.gameObject.tag == "enemy")
        {
            health--;

            Debug.Log(health);

            if (health <= 0)
            {
                health = 0;

                explosion.Play(true);
                Destroy(gameObject);
            }
        }
    }
}
