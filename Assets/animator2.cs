using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class animator2 : MonoBehaviour
{
    Animator anim;

    public int pelletCount;
    public float spreadAngle;
    public GameObject projectile;
    public Transform BarrelExit;
    public float Vel;
    float time;
    public float FireRate = 1.15f;
    public float maxAmmo;
    public float currentAmmo;
    public TextMeshProUGUI ammoDisplay;

    List<Quaternion> pellets;

    void Start()
    {
        ammoDisplay = GameObject.Find("Ammo").GetComponent<TextMeshProUGUI>();

        anim = gameObject.GetComponent<Animator>();

        pellets = new List<Quaternion>(pelletCount);

        for (int i = 0; i < pelletCount; i++)
        {
            pellets.Add(Quaternion.Euler(Vector3.zero));
        }
    }

    void Update()
    {
        ammoDisplay.text = currentAmmo.ToString();

        time += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (currentAmmo > 0)
            {
                if (time > FireRate)
                {
                    currentAmmo--;

                    time = 0;

                    anim.SetTrigger("Active");

                    fire();
                }
            }
        }

    }

    void fire()
    {
        for (int i = 0; i < pelletCount; i++)
        {
            pellets[i] = Random.rotation;
            GameObject pellet = Instantiate(projectile, BarrelExit.position, BarrelExit.transform.rotation);
            pellet.transform.rotation = Quaternion.RotateTowards(pellet.transform.rotation, pellets[i], spreadAngle);
            pellet.GetComponent<Rigidbody>().AddForce(pellet.transform.forward * Vel);

            i++;
        }
    }

	void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "rocketammo")
		{
            if (currentAmmo < maxAmmo)
            {
                currentAmmo = currentAmmo + 4;

                Destroy(other.gameObject);
            }

            while (currentAmmo > maxAmmo)
            {
                currentAmmo--;

                if (currentAmmo == maxAmmo)
                {
                    break;
                }
            }
        }

        if (other.gameObject.tag == "smallrock")
        {
            if (currentAmmo < maxAmmo)
            {
                currentAmmo = currentAmmo + 2;

                Destroy(other.gameObject);
            }

            while (currentAmmo > maxAmmo)
            {
                currentAmmo--;

                if (currentAmmo == maxAmmo)
                {
                    break;
                }
            }
        }
    }
}
