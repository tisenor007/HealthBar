using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    public float healthChangeAmount;
    public GameObject HealthBar;
    public float pHealth;
    public GameObject healStation;
    public GameObject damageStation;
    public int timeBetweenHealthChanges;
    private float maxHealth;
    private int maxTime;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = pHealth;
        timeBetweenHealthChanges = timeBetweenHealthChanges * 60;
        maxTime = timeBetweenHealthChanges;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.transform.localScale = new Vector3(pHealth / maxHealth, 1, 1);
 
        timeBetweenHealthChanges--;
        Debug.Log(timeBetweenHealthChanges);
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
       
        if (timeBetweenHealthChanges <= 0)
        {
            if (other.gameObject.tag == "HealStation")
            {
                AddHealth();
                Debug.Log("aaahh");
                timeBetweenHealthChanges = maxTime;
            }
            if (other.gameObject.tag == "DamageStation")
            {
                RemoveHealth();
                Debug.Log("hhaaa");
                timeBetweenHealthChanges = maxTime;
            }

        }
    }

}
