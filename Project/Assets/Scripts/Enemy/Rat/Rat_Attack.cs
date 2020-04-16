using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines the behaviour of a rat when is in attack state.
/// </summary>
public class Rat_Attack : StateMachineBehaviour
{
    // Public attributes
    public float dangerDistance = 10f;

    // Private attributes
    Enemy_Orientation enemy_Orientation;
    Rat rat;
    IsPlayerNear isPlayerNear;
    Attack attack;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.SetBool("isNear", true);
        animator.SetBool("LeaderAttack", false);

        enemy_Orientation = animator.GetComponent<Enemy_Orientation>();
        rat = animator.gameObject.GetComponent<Rat>();
        isPlayerNear = new IsPlayerNear(animator.gameObject, dangerDistance);
        attack = new Attack(animator.gameObject);
    }


    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerIndex)
    {
        animator.SetBool("isNear", isPlayerNear.Check());
        animator.SetBool("LeaderExist", rat.GetLeader() != null);

        rat.move(attack.GetAction());
        enemy_Orientation.LookAtPlayer();
    }

    //// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}
}
