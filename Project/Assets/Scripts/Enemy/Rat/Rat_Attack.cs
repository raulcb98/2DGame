using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines the behaviour of a rat when is in attack state.
/// </summary>
public class Rat_Attack : StateMachineBehaviour
{
    // Public attributes
    public float speed = 2.5f;
    public float dangerDistance = 5f;

    // Private attributes
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

        // If player is not under range, change state
        if (distance > dangerDistance)
        {
            animator.SetBool("isNear", false);
        }

        // If player is under range, attack
        animator.GetComponent<Enemy_Orientation>().LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }

    //// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}
}
