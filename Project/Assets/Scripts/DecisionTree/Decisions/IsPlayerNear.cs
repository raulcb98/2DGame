using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPlayerNear : Decision
{

    float nearDistance;

    public IsPlayerNear(GameObject agent, float nearDistance) : base(agent) 
    {
        this.nearDistance = nearDistance;
    }

    public override int GetAction()
    {
        throw new System.NotImplementedException();
    }


    public override bool Check()
    {
        Vector2 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 myPos = this.agent.transform.position;

        return Vector2.Distance(myPos, playerPos) < nearDistance;
    }

}
