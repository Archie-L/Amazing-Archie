using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock_run : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider hit)
	{
        if(hit.gameObject.tag == "player")
		{
            anim.SetTrigger("rockhit");
        }
	}
}
