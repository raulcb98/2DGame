using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Attack : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;

    public float dangerDistance = 5f;
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

        animator.GetComponent<EnemyOrientation>().LookAtPlayer();

        animator.GetComponent<Pathfinding.AIDestinationSetter>().target = player;

        if (distance > dangerDistance)
        {
            animator.SetBool("isNear", false);
        }
    }
}
