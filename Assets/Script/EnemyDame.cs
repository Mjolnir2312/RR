using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDame : MonoBehaviour
{
    public float damage;
    float dameRate = 0.5f;
    public float pushBackForce;
    float nextDame;
    // Start is called before the first frame update
    void Start()
    {
        nextDame = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && nextDame < Time.time)
        {
            PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
            thePlayerHealth.HadDame(damage);
            nextDame = dameRate + Time.time;

        }
    }
}
