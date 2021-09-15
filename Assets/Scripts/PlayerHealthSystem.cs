using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    public float healthChangeAmount;
    public GameObject HealthBar;
    public float pHealth;

    public int timeBetweenHealthChanges;
    private float maxHealth;
    private int maxTime;

    private bool playerIsTakingDamage = false;
    private bool playerIsHealing = false;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = pHealth;
        timeBetweenHealthChanges = timeBetweenHealthChanges * 600;
        maxTime = timeBetweenHealthChanges;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.transform.localScale = new Vector3(pHealth / maxHealth, 1, 1);
 
        timeBetweenHealthChanges--;
        Debug.Log(timeBetweenHealthChanges);

        if (pHealth <= 0)
        {
            this.gameObject.SetActive(false);
        }

        if (playerIsHealing == true)
        {
            if (timeBetweenHealthChanges <= 0)
            {
                AddHealth();
                timeBetweenHealthChanges = maxTime;
            }
        }
        if (playerIsTakingDamage == true)
        {
            if (timeBetweenHealthChanges <= 0)
            {
                RemoveHealth();
                timeBetweenHealthChanges = maxTime;
            }
        }
    }

    public void AddHealth()
    {
        pHealth = pHealth + healthChangeAmount;
        if (pHealth >= maxHealth)
        {
            pHealth = maxHealth;
        }
    }

    public void RemoveHealth()
    {
        pHealth = pHealth - healthChangeAmount;
        if (pHealth <= 0)
        {
            pHealth = 0;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HealStation")
        {
            playerIsHealing = true;
        }
        if (other.gameObject.tag == "DamageStation")
        {
            playerIsTakingDamage = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "HealStation")
        {
            playerIsHealing = false;
        }
        if (other.gameObject.tag == "DamageStation")
        {
            playerIsTakingDamage = false;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            RemoveHealth();
        }
    }

}
