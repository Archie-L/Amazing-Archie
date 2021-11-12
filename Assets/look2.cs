using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look2 : MonoBehaviour
{
    public Transform target;

	void Start()
	{

    }

	void Update()
    {
        transform.LookAt(target.eulerAngles + new Vector3(0, 40, 90f));
        transform.LookAt(target.position + new Vector3(0, 0, 0));
    }
}
