using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow2 : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent enemy;
    public Transform Player;
    public Transform Self;

	void Start()
	{
		enemy.SetDestination(Player.position);
	}

	void OnTriggerLeave(Collider other)
	{
		if (other.gameObject.tag == "player")
		{
			Debug.Log("Player left");
			Update();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "player")
		{
			Debug.Log("Player entered");
			enemy.SetDestination(Self.position);
		}
	}

	private void Update()
	{
		enemy.SetDestination(Player.position);
	}
}
