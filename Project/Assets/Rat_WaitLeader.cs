using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat_WaitLeader : StateMachineBehaviour
{
    public float distance = 10f;

    private Rat rat;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rat = animator.gameObject.GetComponent<Rat>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("LeaderExist", rat.GetLeader() != null);

        rat.CalculateLeaderAction(distance);
        Action leaderAction = rat.GetLeader().GetLeaderAction();

        if (leaderAction != null)
        {
            if(leaderAction is Attack)
            {
                animator.SetBool("LeaderAttack", true);
            }

            if(leaderAction is RunAway)
            {
                animator.SetBool("LeaderRunAway", true);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
