using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway : Action
{
    public RunAway(GameObject agent) : base(agent) { }

    public override int GetAction()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if (player.transform.position.x < agent.transform.position.x)
        {
            return Action.RIGHT;
        }
        else
        {
            return Action.LEFT;
        }
    }
}