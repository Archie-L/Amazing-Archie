using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow1 : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent enemy;
    public Transform Player;
    public GameObject hand;
    Animator anim;

	void Start()
	{
        hand.SetActive(false);
    }

	// Update is called once per frame
	void Update()
    {
        enemy.SetDestination(Player.position);

        anim = gameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "player")
        {
            anim.SetTrigger("rockhit");
            hand.SetActive(true);
        }
    }

    void OnTriggerleave(Collider hit)
    {
        if (hit.gameObject.tag == "player")
        {
            hand.SetActive(false);
        }
    }
}
