using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog_Jump : MonoBehaviour
{
    [Range(1, 10)]
    public float jumpVelocity = 5;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    
    Rigidbody2D rb;
    Animator animator;

    const bool RIGHT = true;
    const bool LEFT = false;

    float jumpSleep = 1f;
    float nextJumpTime = 0f;

    bool jumpDirection = false;

    public Sprite sprite;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float x;

        if (jumpDirection == false)
        {
            x = -1;
        }
        else
        {
            x = 1;
        }
                
        if (x != 0)
        {
            JumpAction(x); 
        }
        jumpPhysics();
        jumpAnimation();
    }


    public void JumpAction(float axis)
    {
        if (Time.time >= nextJumpTime)
        {
            rb.velocity = new Vector2(axis, 1) * jumpVelocity; // -1 = left, 0 = nothing, +1 = right
            nextJumpTime = Time.time + jumpSleep;
            jumpDirection = !jumpDirection;

        }
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

        if(rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x/2,0);
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
