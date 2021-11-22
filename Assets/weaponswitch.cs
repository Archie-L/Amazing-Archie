using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponswitch : MonoBehaviour
{
    public GameObject wep1;
    public GameObject wep2;
    public GameObject wep3;

    // Start is called before the first frame update
    void Start()
    {
        wep1.SetActive(true);
        wep2.SetActive(false);
        wep3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            wep1.SetActive(true);
            wep2.SetActive(false);
            wep3.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            wep1.SetActive(false);
			wep2.SetActive(true);
            wep3.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Alpha2))
		{
            wep1.SetActive(false);
            wep2.SetActive(false);
            wep3.SetActive(true);
        }
    }
}
