using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemiess : MonoBehaviour
{
    public Animator anim;
    public int maxHealth = 1000;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    public void TakeDame(int damage)
    {
        currentHealth -= damage;

        anim.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy had died!");

        anim.SetBool("Isdead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

    }
}
