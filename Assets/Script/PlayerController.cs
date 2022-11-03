using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;

    bool grounded;



    Rigidbody2D mybody;
    Animator myanim;
    // Start is called before the first frame update
    void Start()
    {
        mybody = GetComponent<Rigidbody2D> ();
        myanim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void FixedUpdate()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        myanim.SetFloat("speed", Mathf.Abs (xAxis));

        if (xAxis > 0)
        {
            transform.localScale = new Vector3(3, 3);            
        }
        if(xAxis < 0)
        {
            transform.localScale = new Vector3(-3, 3);
        }

        transform.Translate(transform.right * xAxis * Time.deltaTime * moveSpeed);
        transform.Translate(transform.up * yAxis * Time.deltaTime * moveSpeed);

        if (Input.GetKey(KeyCode.Space))
        {
            if(grounded)
            {
                grounded = false;
                mybody.velocity = new Vector2(mybody.velocity.x, jumpHeight);
            }
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "ground")
        {
            grounded = true;
        }
    }
    //attack1
   
}
