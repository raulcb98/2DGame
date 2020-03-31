using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Range(1, 10)]
    public float jumpVelocity = 5;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    
    Rigidbody2D rb;
    Animator animator;

    const bool RIGHT = true;
    const bool LEFT = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxisRaw("Horizontal"); // -1 = left, 0 = nothing, +1 = right
        if(x != 0)
        {
            rb.velocity = new Vector2(x, 1) * jumpVelocity;
        }

        jumpPhysics();
        jumpAnimation();
    }


    void jumpPhysics()
    {

        if (rb.velocity.y < 0)
        {
            animator.SetBool("falling", true);
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

    }

    void jumpAnimation()
    {
        if(rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        } else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        
        if (rb.velocity.y != 0)
        {
            animator.SetBool("jumping", true);
            if(rb.velocity.y < 0)
            {
                animator.SetBool("falling", true);
            }
        } else
        {
            animator.SetBool("jumping", false);
            animator.SetBool("falling", false);
        }
    }
}
