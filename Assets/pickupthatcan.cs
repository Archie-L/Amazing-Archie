using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupthatcan : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider Other)
	{
        if(Other.gameObject.tag == "player")
		{
            anim.SetTrigger("can");
        }
	}
}
