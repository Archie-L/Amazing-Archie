using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor : MonoBehaviour
{
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void OpenDoor()
    {
        door.SetActive(false);
    }

    public void CloseDoor()
    {
        door.SetActive(true);
    }
}
