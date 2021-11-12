using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pooNation : MonoBehaviour
{

    public int childrenCount;
    public GameObject interactor;
    public bool openDoor;
    public bool stopMusic;
    public bool nextWave;

    bool poo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        childrenCount = 0;

        foreach(Transform child in transform)
        {
            if (child.gameObject.active)
            {
                childrenCount += 1;
            }
        }

        if(childrenCount < 1)
        {
            if (!poo)
            {
                Debug.Log("poop");

                if (openDoor)
                {
                    interactor.GetComponent<opendoor>().OpenDoor();
                }

                if (nextWave)
                {

                }

                if (stopMusic)
                {

                }

                poo = true;
            }
        }
    }
}
