using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    public Animator animator;


    public Transform attackPoint1;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 50;


    void Update()
    {       
            if (Input.GetKey(KeyCode.J))
            {
                Attack();
            }     
    }

    void Attack()
    {
        animator.SetTrigger("attack2");

        Collider2D[] hitEnemis = Physics2D.OverlapCircleAll(attackPoint1.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemis)
        {
            enemy.GetComponent<Enemiess>().TakeDame(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint1 == null)
            return;
        Gizmos.DrawWireSphere(attackPoint1.position, attackRange);
    }


}
