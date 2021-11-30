using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneload : MonoBehaviour
{
    public float lifeSpan;
    private float lifeStart;

    // Start is called before the first frame update
    void Start()
    {
        lifeStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > (lifeSpan + lifeStart))
        {
            SceneManager.LoadScene("save");
        }
    }
}
