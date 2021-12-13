using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solider2 : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent enemy;
    public Transform Player;

    public float shootDist = 50f, stopDist = 20f;
    public float WalkSpeed, StopSpeed = 0.5f;

    public float health;
    public float Vel;
    public int gibCount;
    public float spreadAngle;
    public GameObject chunk;
    public Transform chunkExit;
    public GameObject gun;
    public GameObject gun2;
    float time;

    public bool CanFire = false;

    List<Quaternion> gibs;
    List<Quaternion> pellets;

    void Start()
    {
        gun.SetActive(false);
        gun2.SetActive(false);

        gibs = new List<Quaternion>(gibCount);

        for (int i = 0; i < gibCount; i++)
        {
            gibs.Add(Quaternion.Euler(Vector3.zero));
        }
    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider Collision)
    {
        if (Collision.gameObject.tag == "bullet")
        {
            health -= 1;

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

        if (Collision.gameObject.tag == "playerExplosion")
        {
            health -= 4;

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

        if (Collision.gameObject.tag == "explosion")
        {
            health -= 4;

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

    // Update is called once per frame
    void FixedUpdate()
    {
        enemy.SetDestination(Player.position);

        if (CanFire)
        {
            fire();
        }

        if (Vector3.Distance(Player.position, transform.position) > shootDist)
        {
            WalkNoShoot();
        }

        if (Vector3.Distance(Player.position, transform.position) <= shootDist)
        {
            WalkAndShoot();
        }

        if (Vector3.Distance(Player.position, transform.position) <= stopDist)
		{
            StopAndShoot();
        }
    }

    void fire()
    {
        gun.SetActive(true);
        gun2.SetActive(true);
    }

    void WalkNoShoot()
    {
        enemy.speed = WalkSpeed;
        CanFire = false;
        gun.SetActive(false);
        gun2.SetActive(false);
        Debug.Log("out");
    }

    void WalkAndShoot()
	{
        enemy.speed = WalkSpeed;
        CanFire = true;
        Debug.Log("poo");
    }

	void StopAndShoot()
	{
        enemy.speed = StopSpeed;
        CanFire = true;
        Debug.Log("stop");
    }
}
