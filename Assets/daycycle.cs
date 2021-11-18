using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daycycle : MonoBehaviour
{
    public float RotationSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * (RotationSpeed * Time.deltaTime));
    }
}
