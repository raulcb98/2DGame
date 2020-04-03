using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Frog : StateMachineBehaviour
{
    public float dangerDistance = 5f;

    Transform player;
    Rigidbody2D rb;

    bool LEFT = true;
    bool RIGHT = false;

    float jumpVelocity = 5;

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
        float distance = Mathf.Abs(player.position.x - rb.position.x);

        if (distance > dangerDistance)
        {
            animator.SetBool("isNear", false);
        }
        animator.GetComponent<Jump>().JumpAction(-1f);
    }

    //// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}
}
