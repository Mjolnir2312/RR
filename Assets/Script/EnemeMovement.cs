using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float enemySpeed;

    Rigidbody2D enemyRB;
    Animator enemyAnim;

    public GameObject enemyGP;
    bool facingRight = true;
    float facingTime = 5f;
    float nextFlip = 0f;
    bool canFlip = true;

    void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D> ();
        enemyAnim = GetComponentInChildren<Animator> ();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextFlip)
        {
            nextFlip = Time.time + facingTime;
            flip();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(facingRight && other.transform.position.x < transform.position.x)
            {
                flip();
                enemyAnim.SetTrigger("enemyattack");
            }
            else if(!facingRight && other.transform.position.x > transform.position.x)
            {
                flip();
                enemyAnim.SetTrigger("enemyattack");
            }
            canFlip = false;
        }
    }



    //void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other.tag == "Player")
    //    { 
    //        if(!facingRight)
    //            enemyRB.AddForce (new Vector2 (-2, 0) * enemySpeed);
    //        else 
    //        { 
    //            enemyRB.AddForce (new Vector2 (2, 0) * enemySpeed); 
    //        }
    //        enemyAnim.SetBool ("enemyrun", true);
    //    }
    //}

    void flip()
    {
        if (!canFlip)
            return;
        facingRight = !facingRight;
        Vector3 theScale = enemyGP.transform.localScale;
        theScale.x *= -1;
        enemyGP.transform.localScale = theScale;
    }
}
