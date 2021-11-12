using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    public void OpenDoor()
    {
        anim.SetBool("open 0", true);
    }

    public void CloseDoor()
    {
        anim.SetBool("open 0", false);
    }
}
