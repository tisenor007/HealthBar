using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int speed;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(-1, 0, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        direction *= -1;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
