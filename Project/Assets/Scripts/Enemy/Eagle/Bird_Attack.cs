using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines the eagle behaviour in the state attack.
/// </summary>
public class Bird_Attack : StateMachineBehaviour
{
    // Public variables
    public float dangerDistance = 5f;

    // Private variables
    Transform player;
    Rigidbody2D rb;

    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isNear", true);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerIndex)
    {
        // Calculate distance
        float distance = Mathf.Abs(player.position.x - rb.position.x);

        // If target is under distance, move to target
        animator.GetComponent<Enemy_Orientation>().LookAtPlayer();
        animator.GetComponent<Pathfinding.AIDestinationSetter>().target = player;

        // If target is not under distance, change state
        if (distance > dangerDistance)
        {
            animator.SetBool("isNear", false);
        }
    }
}
