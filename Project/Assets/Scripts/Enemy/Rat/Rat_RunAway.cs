using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Defines the rat behaviour when is in the state run away.
/// </summary>
public class Rat_RunAway : StateMachineBehaviour
{
    // Public attributes
    public float dangerDistance = 10f;

    // Private attributes
    Enemy_Orientation enemy_Orientation;
    Rat rat;
    IsPlayerNear isPlayerNear;
    RunAway runAway;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.SetBool("isNear", true);
        animator.SetBool("LeaderRunAway", false);

        enemy_Orientation = animator.gameObject.GetComponent<Enemy_Orientation>();
        rat = animator.gameObject.GetComponent<Rat>();
        isPlayerNear = new IsPlayerNear(animator.gameObject, dangerDistance);
        runAway = new RunAway(animator.gameObject);
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerIndex)
    {
        animator.SetBool("isNear", isPlayerNear.Check());
        animator.SetBool("LeaderExist", rat.GetLeader() != null);

        rat.move(runAway.GetAction());
        enemy_Orientation.NoLookAtPlayer();
    }

    //// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}
}
