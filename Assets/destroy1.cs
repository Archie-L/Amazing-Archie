using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy1 : MonoBehaviour
{
    public float lifeSpan;
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
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ground")
        {
            Debug.Log("ground hit");
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "enemy")
        {
            Debug.Log("enemy hit");
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "ground")
        {
            Debug.Log("ground hit");
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "enemy")
        {
            Debug.Log("enemy hit");
            Destroy(gameObject);
        }
    }
}
