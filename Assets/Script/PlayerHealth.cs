using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Animator charAnim;

    public float maxHealth;
    float currentHealth;

    public Slider playerHealthSlider;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = maxHealth;
    }

    // Update is called once per frame

    public void HadDame(float damage)
    {
        currentHealth -= damage;
        playerHealthSlider.value = currentHealth;
        charAnim.SetTrigger("takehit");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        charAnim.SetBool("die", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
