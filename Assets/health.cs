using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public TextMeshProUGUI healthDisplay;

    // Start is called before the first frame update
    void Start()
    {
        healthDisplay = GameObject.Find("Health").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = currentHealth.ToString();

        if (currentHealth <= 0)
		{
            currentHealth = 0;

            SceneManager.LoadScene("save");
        }
    }

    void OnCollisionEnter(Collision coll)
	{
		if(coll.gameObject.tag == "enemybullet")
		{
            currentHealth = currentHealth - 10f;
		}

        if(coll.gameObject.tag == "enemyrocket")
		{
            currentHealth = currentHealth - 25f;
		}

        if (coll.gameObject.tag == "enemyhand")
        {
            currentHealth = currentHealth - 50f;
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "enemybullet")
        {
            currentHealth = currentHealth - 10f;

            Destroy(coll.gameObject);
        }

        if (coll.gameObject.tag == "deathbarrier")
        {
            currentHealth = 0f;
        }

        if (coll.gameObject.tag == "enemyrocket")
        {
            currentHealth = currentHealth - 25f;

            Destroy(coll.gameObject);
        }

        if (coll.gameObject.tag == "enemyhand")
        {
            currentHealth = currentHealth - 50f;
        }

        if (coll.gameObject.tag == "explosion")
        {
            currentHealth = currentHealth - 40f;
        }

        if (coll.gameObject.tag == "largehealth")
        {
            if (currentHealth < maxHealth)
            {
                currentHealth = currentHealth + 50;

                Destroy(coll.gameObject);
            }

            while (currentHealth > maxHealth)
            {
                currentHealth--;

                if (currentHealth == maxHealth)
                {
                    break;
                }
            }
        }

        if (coll.gameObject.tag == "midhealth")
        {
            if(currentHealth < maxHealth)
			{
                currentHealth = currentHealth + 25;

                Destroy(coll.gameObject);
            }

            while (currentHealth > maxHealth)
            {
                currentHealth--;

                if (currentHealth == maxHealth)
                {
                    break;
                }
            }
        }

        if (coll.gameObject.tag == "smallhealth")
        {
            if (currentHealth < maxHealth)
            {
                currentHealth = currentHealth + 5;

                Destroy(coll.gameObject);
            }

            while (currentHealth > maxHealth)
            {
                currentHealth--;

                if (currentHealth == maxHealth)
                {
                    break;
                }
            }
        }
    }
}
