using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Action
{
    public Attack(GameObject agent) : base(agent) { }

    public override int GetAction()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if(player.transform.position.x < agent.transform.position.x)
        {
            return Action.LEFT;
        } else
        {
            return Action.RIGHT;
        }
    }
}
