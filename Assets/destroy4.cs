using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy4 : MonoBehaviour
{
    public float lifeSpan;
    public ParticleSystem explosion;
    private float lifeStart;

    // Start is called before the first frame update
    void Start()
    {
        lifeStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > (lifeSpan + lifeStart))
        {
            explosion.Play(true);
            Destroy(gameObject);
        }
    }
}
