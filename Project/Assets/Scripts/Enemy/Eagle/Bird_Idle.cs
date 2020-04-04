using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines the eagle behaviour when in the state idle.
/// </summary>
public class Bird_Idle : StateMachineBehaviour
{
    // Public attributes
    public float dangerDistance = 5f;

    // Private attributes
    Transform player;
    Rigidbody2D rb;

    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isNear", false);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
   
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerIndex)
    {
        // Calculate distance
        float distance = Mathf.Abs(player.position.x - rb.position.x);

        // If player isn't under distance, don't move
        animator.GetComponent<Enemy_Orientation>().LookAtPlayer();
        animator.GetComponent<Pathfinding.AIDestinationSetter>().target = animator.transform;

        // If player is under distance, change state
        if (distance < dangerDistance)
        {
            animator.SetBool("isNear", true);
        }
    }

    //// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}
}
