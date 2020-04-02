using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Near : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;

    public float dangerDistance = 5f; 
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
        float distance = Mathf.Abs(player.position.x - rb.position.x);

        if(distance < dangerDistance)
        {

            float valor = Random.Range(0.0f, 1.0f);

            if (valor == 0.5f)
            {
                valor += 1f;
            }

            animator.SetFloat("Random", valor);

            animator.SetBool("isNear", true);

        }
    }

    //// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
        
    //}
}
