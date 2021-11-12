using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent enemy;
    public Transform Player;
    public Transform Self;

    bool following = false;

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (following == false)
            {
                Follow();
            }

            if (following == true)
            {
                StopFollowing();
            }
        }
    }

    void Follow()
    {
        Debug.Log("Following");

        while (following == false)
        {
            enemy.SetDestination(Player.position);
        }
    }

    void StopFollowing()
    {
        Debug.Log("Not follwing");
        enemy.SetDestination(Self.position);

        following = false;
    }
}
