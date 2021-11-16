using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject Music;

    void Start()
    {
        enemy.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            enemy.SetActive(true);

            Destroy(this.gameObject);

            Music.GetComponent<AudioSource>().Play();
        }
    }
}
