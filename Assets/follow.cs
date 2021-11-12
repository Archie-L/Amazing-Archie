using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent enemy;
    public Transform Player;

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(Player.position);
    }
}
