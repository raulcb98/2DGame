using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines the frog behaviour in the state jump.
/// </summary>
public class Frog_Jump : MonoBehaviour
{
    // Public attributes
    [Range(1, 10)]
    public float jumpVelocity = 5;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    

    // Private attributes
    Rigidbody2D rb;
    Animator animator;

    float jumpSleep = 1f;
    float nextJumpTime = 0f;
    bool jumpDirection = false;
    FrogDecisionTree decisionTree;


    // Awakeis called once when the object is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        decisionTree = GetComponent<FrogDecisionTree>();
    }


    // Update is called once per frame
    void Update()
    {
        // Jump left and right alternatively
        int actionId = decisionTree.Decide();

        if (actionId == Action.LEFT) JumpAction(-1);
        if (actionId == Action.RIGHT) JumpAction(1);
        if (actionId == Action.UP) JumpAction(0);

        jumpPhysics();
        jumpAnimation();
    }


    // Control jump frecuence
    public void JumpAction(float xAxis)
    {
        float yAxis = 1;
        if (xAxis == 0) yAxis = 1.5f;

        if (Time.time >= nextJumpTime)
        {
            rb.velocity = new Vector2(xAxis, yAxis) * jumpVelocity; // -1 = left, 0 = up, +1 = right
            nextJumpTime = Time.time + jumpSleep;
            jumpDirection = !jumpDirection;
        }
    }


    // Control jump physics
    void jumpPhysics()
    {
        // Apply physics
        if (rb.velocity.y < 0)
        {
            animator.SetBool("falling", true);
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        // To avoid slide
        if(rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x/4,0);
        }
    }


    // Control jump animation
    void jumpAnimation()
    {
        // Frog orientation
        if(rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        } else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        
        // Update animation state machine
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
