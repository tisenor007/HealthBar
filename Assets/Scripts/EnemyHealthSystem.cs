using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    public float eHealth;
    public float healthChangeAmount;
    public GameObject HealthBar;
    public GameObject Canvas;
    public GameObject Camera;
    private float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = eHealth;
    }
    // Update is called once per frame
    void Update()
    {
        HealthBar.transform.localScale = new Vector3(eHealth / maxHealth, 1, 1);
        Canvas.transform.LookAt(Camera.transform);

        if (eHealth <=0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void AddHealth()
    {
        eHealth = eHealth + healthChangeAmount;
        if (eHealth >= maxHealth)
        {
            eHealth = maxHealth;
        }
    }

    public void RemoveHealth()
    {
        eHealth = eHealth - healthChangeAmount;
        if (eHealth <= 0)
        {
            eHealth = 0;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            RemoveHealth();
        }
    }
}
