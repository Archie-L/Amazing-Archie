using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject enemy;
    public AudioSource audioSource;

    void Start()
    {
        enemy.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "enemyspawn")
        {
            enemy.SetActive(true);

            audioSource.Play();
        }
    }
}
