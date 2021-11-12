using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    public int pelletCount;
    public float spreadAngle;
    public GameObject projectile;
    public Transform BarrelExit;
    public float Vel;
    float time;
    public float FireRate = 1.15f;

    List<Quaternion> pellets;

    void Start()
    {
        pellets = new List<Quaternion>(pelletCount);

        for (int i = 0; i < pelletCount; i++)
        {
            pellets.Add(Quaternion.Euler(Vector3.zero));
        }
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time > FireRate)
        {
            time = 0;

            fire();
        }
    }

    void fire()
    {
        for (int i = 0; i < pelletCount; i++)
        {
            pellets[i] = Random.rotation;
            GameObject pellet = Instantiate(projectile, BarrelExit.position, BarrelExit.transform.rotation);
            pellet.GetComponent<Rigidbody>().AddForce(pellet.transform.forward * Vel);

            i++;
        }
    }

}
